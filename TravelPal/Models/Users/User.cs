using System.Collections.Generic;
using TravelPal.Enums;
using TravelPal.Models.Travels;

namespace TravelPal.Models.Users
{
    public class User : IUser
    {
        public List<Travel> Travels { get; set; } = new()
        {
           new Vacation("stockholm", Enums.Country.Sweden, 5, true),
           new WorkTrip("stockholm", Enums.Country.Sweden, 5, "meeting att clarion hotel 5pm"),
        };
        public string Username { get; set; }
        public string Password { get; set; }
        public Country Location { get; set; }

        public User(string username, string password, Country location)
        {
            Username = username;
            Password = password;
            Location = location;
        }
        public User()
        {

        }
    }
}
