using System.Collections.Generic;
using TravelPal.Models.Users;

namespace TravelPal.Managers
{
    public class UserManager
    {
        public List<IUser> Users { get; set; } = new()
        {

            new User("test", "password", Enums.Country.Sweden),
            new Admin("admin", "password", Enums.Country.Sweden)

        };
        public IUser? SignedInUser { get; set; }

        public bool AddUser(IUser user)
        {
            if (ValidateUsername(user.Username))
            {
                User newUser = new(user.Username, user.Password, user.Location);

                Users.Add(newUser);

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
        public bool SignInUser(string username, string password)
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
        public void SignOutUser()
        {
            SignedInUser = null;
        }


    }
}
