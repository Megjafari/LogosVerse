using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogosVerse.Services;


public class NotificationService
{
    private BibleService bibleService;
    private UserService userService;
    private Timer dailyTimer;

    public NotificationService(BibleService bibleService, UserService userService)
    {
        this.bibleService = bibleService;
        this.userService = userService;
    }

    public void StartDailyNotifications()
    {
        // Simulerar dagliga notiser - i verkligheten skulle detta vara en riktig timer
        dailyTimer = new Timer(SendDailyVerses, null, TimeSpan.Zero, TimeSpan.FromSeconds(30)); // Test: var 30e sekund
    }

    public void StopDailyNotifications()
    {
        dailyTimer?.Dispose();
    }

    private void SendDailyVerses(object state)
    {
        // I en riktig app skulle detta skicka push-notiser
        // Här simulerar vi bara i konsolen
        Console.WriteLine("\n[NOTIS] Daglig bibelvers skulle skickas nu till användare...");
    }
}
