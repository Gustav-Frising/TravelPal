using System.Collections.Generic;
using TravelPal.Models.Users;

namespace TravelPal.Managers
{
    public class UserManager
    {
        public static List<IUser> Users { get; set; } = new()
        {

            new User("test", "password",Enums.Country.Sweden),
            new Admin("admin", "password", Enums.Country.Sweden)

        };
        public static IUser? SignedInUser { get; set; }

        public bool AddUSer(IUser user)
        {
            if (ValidateUsername(user.Username))
            {
                Users.Add(user);

                return true;
            }
            return false;
        }
        public void RemoveUSer(IUser user)
        {

        }
        public bool UppdateUsername()
        {
            return true;
        }
        private bool ValidateUsername(string username)
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

        }


    }
}
