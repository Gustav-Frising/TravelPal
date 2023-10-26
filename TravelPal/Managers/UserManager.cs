using System.Collections.Generic;
using TravelPal.Models.Users;

namespace TravelPal.Managers
{
    public static class UserManager
    {
        public static List<IUser> Users { get; set; } = new()
        {

            new User("test", "password", Enums.Country.Sweden),/*{new Travel (Destination = "stockholm",Countries = Enums.Country.Sweden, TravelDays= 5) },*/
            new Admin("admin", "password", Enums.Country.Sweden)

        };
        public static IUser? SignedInUser { get; set; }

        public static bool AddUser(IUser user)
        {
            if (ValidateUsername(user.Username))
            {
                User newUser = new(user.Username, user.Password, user.Location);

                Users.Add(newUser);

                return true;
            }
            return false;
        }
        public static void RemoveUSer(IUser user)
        {

        }
        public static bool UppdateUsername()
        {
            return true;
        }
        private static bool ValidateUsername(string username)
        {
            bool isValidUSername = true;

            foreach (var user in Users)
            {
                if (user.Username == username)
                {
                    isValidUSername = false;
                }
            }
            return isValidUSername;
        }
        public static bool SignInUser(string username, string password)
        {
            foreach (var user in Users)
            {
                if (user.Username == username && user.Password == password)
                {
                    //user was found
                    SignedInUser = user;

                    return true;
                }
            }
            return false;
        }
        public static void SignOutUser()
        {
            SignedInUser = null;
        }


    }
}
