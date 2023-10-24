using System.Collections.Generic;
using TravelPal.Enums;

namespace TravelPal.Models
{
    class User : IUser
    {
        public List<Travel> Travels { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Country Location { get; set; }

        public User(string username, string password, Country location)
        {
            username = Username;
            password = Password;
            location = Location;
        }
    }
}
