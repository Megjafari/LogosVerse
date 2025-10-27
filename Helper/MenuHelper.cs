using LogosVerse.Models;
using Logoverse.Models;
using System;

namespace LogosVerse.Helper;
public static class MenuHelper
{
    public static void ShowMainMenu()       //Visar huvudmenyn
    {
        Console.Clear();
        Console.WriteLine("=== BIBLE APP ===");
        Console.WriteLine("1. Register");
        Console.WriteLine("2. Login");
        Console.WriteLine("3. Read Bible (Guest)");
        Console.WriteLine("4. Exit");
        Console.Write("Choose option: ");
    }

    public static void ShowUserMenu(string userName)    //Visar användarmenyn
    {
        Console.Clear();
        Console.WriteLine($"=== Welcome {userName} ===");
        Console.WriteLine("1. Read Bible");
        Console.WriteLine("2. Ask AI Question");
        Console.WriteLine("3. Settings");
        Console.WriteLine("4. Logout");
        Console.Write("Choose option: ");
    }

    public static void ShowBibleMenu()      //Visar bibelmenyn
    {
        Console.Clear();
        Console.WriteLine("=== READ BIBLE ===");
        Console.WriteLine("Choose book:");
        Console.WriteLine("1. Genesis");
        Console.WriteLine("2. Psalms");
        Console.WriteLine("3. Matthew");
        Console.WriteLine("4. Mark");
        Console.WriteLine("5. Luke");
        Console.WriteLine("6. John");
        Console.WriteLine("7. Romans");
        Console.WriteLine("8. Back");
        Console.Write("Choose book: ");
    }

    public static void ShowSettingsMenu(User user)      //Visar inställningsmenyn
    {
        Console.Clear();
        Console.WriteLine("=== SETTINGS ===");
        Console.WriteLine($"Daily notifications: {(user.DailyNotifications ? "ON" : "OFF")}");
        Console.WriteLine("\n1. Change notification settings");
        Console.WriteLine("2. Change password");
        Console.WriteLine("3. Back");
        Console.Write("Choose: ");
    }

    public static void ShowRegistrationHeader() //Visar registreringsrubriken
    {
        Console.Clear();
        Console.WriteLine("=== REGISTRATION ===");
    }

    public static void ShowLoginHeader()    //Visar inloggningsrubriken
    {
        Console.Clear();
        Console.WriteLine("=== LOGIN ===");
    }

    public static void ShowAIMenu() //Visar AI-frågerubriken
    {
        Console.Clear();
        Console.WriteLine("=== ASK AI QUESTION ===");
        Console.WriteLine("Enter your Bible question:");
    }

    public static string GetBookName(string choice) //Hämtar bokens namn baserat på användarens val
    {
        return choice switch
        {
            "1" => "GEN",
            "2" => "PSA",
            "3" => "MAT",
            "4" => "MAR",
            "5" => "LUK",
            "6" => "JHN",
            "7" => "ROM",
            _ => null
        };
    }

    public static string GetBookDisplayName(string bookCode)    //Hämtar bokens visningsnamn baserat på bokens kod
    {
        return bookCode switch
        {
            "GEN" => "Genesis",
            "PSA" => "Psalms",
            "MAT" => "Matthew",
            "MAR" => "Mark",
            "LUK" => "Luke",
            "JHN" => "John",
            "ROM" => "Romans",
            _ => bookCode
        };
    }

    public static void PressAnyKeyToContinue()      //Väntar på att användaren trycker på en tangent för att fortsätta
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    public static void ShowErrorMessage(string message)     //Visar ett felmeddelande
    {
        Console.WriteLine($"\nError: {message}");
        PressAnyKeyToContinue();
    }

    public static void ShowSuccessMessage(string message)       //Visar ett framgångsmeddelande
    {
        Console.WriteLine($"\n✓ {message}");
        PressAnyKeyToContinue();
    }

    public static void ShowDailyVerse(BibleVerse verse) //Visar dagens bibelvers
    {
        Console.WriteLine("\n=== DAILY BIBLE VERSE ===");
        Console.WriteLine(verse.ToString());
        Console.WriteLine("========================");
    }

    public static void ShowWelcomeMessage(string userName, bool showDailyVerse = false) //Visar välkomstmeddelande
    {
        Console.WriteLine($"\nWelcome back {userName}!");
        if (showDailyVerse)
        {
            Console.WriteLine("Daily Bible verse will be shown each time you login.");
        }
    }
}