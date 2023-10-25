using TravelPal.Enums;

namespace TravelPal.Models.Users
{
    public class Admin : IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Country Location { get; set; }
        public Admin(string username, string password, Country location)
        {
            username = Username;
            password = Password;
            location = Location;
        }
    }
}
