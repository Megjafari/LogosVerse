using LogosVerse.Models;
using LogosVerse.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LogosVerse.Helper;

public static class BibleApp
{
    private static UserService userService;
    private static BibleService bibleService;
    private static AIService aiService;
    private static NotificationService notificationService;
    private static User currentUser;

    public static void Run()    // Entry point för applikationen
    { try
        {
            InitializeServices();   // Initialisera tjänster


            while (true)
            {
            if (currentUser == null)
            {
                ShowMainMenu();
            }
            else
            {
                ShowUserMenu();
            }
        }
    }
        catch (Exception ex)
        {
            Console.WriteLine($"Error starting application: {ex.Message}");
            Console.WriteLine("Please make sure BIBLE_API_KEY environment variable is set.");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }

    private static void InitializeServices()    // Initialiserar alla tjänster som används i applikationen
    {
        // Hämta environment variables direkt
        string bibleApiKey = Environment.GetEnvironmentVariable("BIBLE_API_KEY") ??
                           throw new Exception("BIBLE_API_KEY environment variable is not set");

        string openAIApiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY") ??
                            "no-openai-key"; // inget ännu

        string usersFilePath = Environment.GetEnvironmentVariable("USERS_FILE_PATH") ??
                             "users.json";

        userService = new UserService(usersFilePath);       // Användarhanteringstjänst
        bibleService = new BibleService(bibleApiKey);
        aiService = new AIService(openAIApiKey);
        notificationService = new NotificationService(bibleService, userService);
        notificationService.StartDailyNotifications();

        Console.WriteLine("Services initialized successfully!");
    }

    private static void ShowMainMenu()
    {
        MenuHelper.ShowMainMenu();
        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                RegisterUser();
                break;
            case "2":
                Login();
                break;
            case "3":
                ReadBibleAsGuest();
                break;
            case "4":
                ExitApplication();
                break;
            default:
                MenuHelper.ShowErrorMessage("Invalid choice. Please try again.");
                break;
        }
    }

    private static void ShowUserMenu()
    {
        MenuHelper.ShowUserMenu(currentUser.username);
        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                ReadBible();
                break;
            case "2":
                AskAI();
                break;
            case "3":
                ShowSettings();
                break;
            case "4":
                Logout();
                break;
            default:
                MenuHelper.ShowErrorMessage("Invalid choice. Please try again.");
                break;
        }
    }

    private static void RegisterUser()
    {
        MenuHelper.ShowRegistrationHeader();

        var user = new User();

        Console.Write("Enter email or phone number: ");
        string contact = Console.ReadLine();

        if (contact.Contains("@"))
            user.email = contact;
        else
            user.phoneNumber = contact;

        Console.Write("Enter name (optional): ");
        user.username = Console.ReadLine();

        Console.Write("Enter password: ");
        user.password = Console.ReadLine();

        Console.Write("Do you want daily notifications? (y/n): ");
        user.DailyNotifications = Console.ReadLine().ToLower() == "y";

        if (userService.RegisterUser(user))
        {
            MenuHelper.ShowSuccessMessage("Registration successful! You can now login.");
        }
        else
        {
            MenuHelper.ShowErrorMessage("User already exists. Please use different email/phone.");
        }
    }

    private static void Login()
    {
        MenuHelper.ShowLoginHeader();

        Console.Write("Enter email/phone: ");
        string contact = Console.ReadLine();

        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        currentUser = userService.Login(contact, password);

        if (currentUser != null)
        {
            MenuHelper.ShowWelcomeMessage(currentUser.username, currentUser.DailyNotifications);

            if (currentUser.DailyNotifications)
            {
                var dailyVerse = bibleService.GetRandomVerse();
                MenuHelper.ShowDailyVerse(dailyVerse);
            }

            MenuHelper.PressAnyKeyToContinue();
        }
        else
        {
            MenuHelper.ShowErrorMessage("Wrong email/phone or password.");
        }
    }

    private static void ReadBibleAsGuest()
    {
        ReadBibleImplementation("guest").GetAwaiter().GetResult();
    }

    private static void ReadBible()
    {
        ReadBibleImplementation(currentUser.username).GetAwaiter().GetResult();
    }

    private static async Task ReadBibleImplementation(string userName)  // Asynkron metod för att läsa bibeln
    {
        Console.Clear();
        Console.WriteLine($"=== READ BIBLE - {userName.ToUpper()} ===");

        MenuHelper.ShowBibleMenu();
        string bookChoice = Console.ReadLine();

        if (bookChoice == "8") return;

        string book = MenuHelper.GetBookName(bookChoice);
        if (book == null)
        {
            MenuHelper.ShowErrorMessage("Invalid book choice.");
            return;
        }

        Console.Write("Enter chapter: ");
        if (!int.TryParse(Console.ReadLine(), out int chapter))
        {
            MenuHelper.ShowErrorMessage("Invalid chapter number.");
            return;
        }

        Console.Write("Enter verse (0 for entire chapter): ");
        if (!int.TryParse(Console.ReadLine(), out int verse))
        {
            MenuHelper.ShowErrorMessage("Invalid verse number.");
            return;
        }

        await DisplayBibleText(book, chapter, verse);
        MenuHelper.PressAnyKeyToContinue();
    }

    private static async Task DisplayBibleText(string book, int chapter, int verse)
    {
        string bookName = MenuHelper.GetBookDisplayName(book);
        Console.WriteLine($"\n{bookName} {chapter}:{verse}");
        Console.WriteLine("Fetching from API.Bible...");

        if (verse == 0)
        {
            var chapterVerses = await bibleService.GetChapterAsync(book, chapter);
            if (chapterVerses.Count == 0)
            {
                Console.WriteLine("No verses found for this chapter.");
                return;
            }

            foreach (var v in chapterVerses)
            {
                Console.WriteLine($"\n{v.Text}");
            }
        }
        else
        {
            var singleVerse = await bibleService.GetVerseAsync(book, chapter, verse);
            if (singleVerse != null)
            {
                Console.WriteLine($"\n{singleVerse.Text}");
            }
            else
            {
                Console.WriteLine("Verse not found.");
            }
        }
    }

    private static void AskAI()
    {
        MenuHelper.ShowAIMenu();
        string question = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(question))
        {
            MenuHelper.ShowErrorMessage("No question entered.");
            return;
        }

        Console.WriteLine("\nAI Answer:");
        string response = aiService.GetExplanation(question);
        Console.WriteLine(response);

        MenuHelper.PressAnyKeyToContinue();
    }

    private static void ShowSettings()
    {
        MenuHelper.ShowSettingsMenu(currentUser);
        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                ToggleNotifications();
                break;
            case "2":
                ChangePassword();
                break;
            case "3":
                // Back
                break;
            default:
                MenuHelper.ShowErrorMessage("Invalid choice.");
                break;
        }
    }

    private static void ToggleNotifications()
    {
        Console.Write("Do you want daily notifications? (y/n): ");
        currentUser.DailyNotifications = Console.ReadLine().ToLower() == "y";

        if (userService.UpdateUser(currentUser))
        {
            MenuHelper.ShowSuccessMessage("Settings saved!");
        }
        else
        {
            MenuHelper.ShowErrorMessage("Could not save settings.");
        }
    }

    private static void ChangePassword()
    {
        Console.Write("Enter current password: ");
        string currentPassword = Console.ReadLine();

        if (currentPassword != currentUser.password)
        {
            MenuHelper.ShowErrorMessage("Wrong password.");
            return;
        }

        Console.Write("Enter new password: ");
        string newPassword = Console.ReadLine();

        currentUser.password = newPassword;

        if (userService.UpdateUser(currentUser))
        {
            MenuHelper.ShowSuccessMessage("Password changed!");
        }
        else
        {
            MenuHelper.ShowErrorMessage("Could not change password.");
        }
    }

    private static void Logout()
    {
        currentUser = null;
        MenuHelper.ShowSuccessMessage("You are now logged out.");
    }

    private static void ExitApplication()
    {
        Console.WriteLine("\nThank you for using Bible App!");
        Thread.Sleep(1000);
        Environment.Exit(0);
    }
}