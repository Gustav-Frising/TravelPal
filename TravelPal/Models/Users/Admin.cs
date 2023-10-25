using TravelPal.Enums;

namespace TravelPal.Models.Users
{
    class Admin : IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Country Location { get; set; }
        public Admin(string username, string password, Country location)
        {
            Username = username;
            Password = password;
            Location = location;
        }
    }
}
