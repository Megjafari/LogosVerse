using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogosVerse.Models
{
    public class User       //Definierar en klass som heter User
    {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public bool DailyNotifications { get; set; }

        public string GetContactInfo() => !string.IsNullOrEmpty(email) ? email : phoneNumber;   //Detta betyder att om email inte är null eller tomt, returnera email, annars returnera phoneNumber

    }
}
