using LogosVerse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LogosVerse.Services;

public class UserService        
{
    private List<User> users;
    private string dataFile;

    public UserService(string dataFile)
    {
        this.dataFile = dataFile;
        users = new List<User>();
        LoadUsers();
    }

    public bool RegisterUser(User user)     
    {
        if (UserExists(user.email, user.phoneNumber)) return false;
        users.Add(user);
        SaveUsers();
        return true;
    }

    public User Login(string contact, string password)
    {
        return users.FirstOrDefault(u => (u.email == contact || u.phoneNumber == contact) && u.password == password);
    }

    public bool UpdateUser(User user)
    {
        var existingUser = users.FirstOrDefault(u => u.email == user.email || u.phoneNumber == user.phoneNumber);
        if (existingUser == null) return false;

        existingUser.username = user.username;
        existingUser.password = user.password;
        existingUser.DailyNotifications = user.DailyNotifications;
        SaveUsers();
        return true;
    }

    public bool UserExists(string email, string phone) =>
        users.Any(u => u.email == email || u.phoneNumber == phone);

    private void LoadUsers()
    {
        if (File.Exists(dataFile))
        {
            try
            {
                string json = File.ReadAllText(dataFile);
                users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
            }
            catch { /* Ignore errors */ }
        }
    }

    private void SaveUsers()
    {
        try
        {
            string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(dataFile, json);
        }
        catch { /* Ignore errors */ }
    }
}


