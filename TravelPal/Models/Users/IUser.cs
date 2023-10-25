using TravelPal.Enums;

namespace TravelPal.Models.Users
{
    public interface IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Country Location { get; set; }

    }
}
