using System.Collections.Generic;
using System.Windows;
using TravelPal.Models.PackingListItems;
using TravelPal.Models.Travels;
using TravelPal.Models.Users;

namespace TravelPal.Managers
{
    public static class UserManager
    {
        public static List<IUser> Users { get; set; } = new()
        {
            new User {
                Username = "a",
                Password = "a",
                Location = Enums.Country.Sweden,
                Travels = new List<Travel>()
                {
                    new Vacation()
                    {
                        Destination = "stockholm",
                        Countries = Enums.Country.Sweden,
                        Travellers = 2,
                        AllInclusive = true,
                        Packinglist = new List<IPackingListItem>()
                        {
                            new TravelDocument()
                            {
                                Name = "Health Insurance",
                                Required = true,
                            },

                            new OtherItem()
                            {
                                Name = "Bathing shorts",
                                Quantity = 1,
                            }
                        }
                    },
                     new WorkTrip()
                    {
                        Destination = "stockholm",
                        Countries = Enums.Country.Sweden,
                        Travellers = 2,
                        MeetingDetails = "Conferance Friday startin at 8",
                        Packinglist = new List<IPackingListItem>()
                        {
                            new TravelDocument()
                            {
                                Name = "Passport",
                                Required = true,
                            },

                            new OtherItem()
                            {
                                Name = "Briefcase",
                                Quantity = 1,
                            }
                        }
                    }
                }
            },

            new Admin("admin", "password", Enums.Country.Sweden),
        };
        public static IUser? SignedInUser { get; set; }

        public static bool AddUser(IUser user)
        {
            if (ValidateUser(user.Username))
            {
                User newUser = new(user.Username, user.Password, user.Location);
                if (user.Location <= 0)
                {
                    MessageBox.Show("You must add Country");
                    return false;
                }
                else if (string.IsNullOrWhiteSpace(user.Password))
                {
                    MessageBox.Show("Must add a password");
                    return false;
                }

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
        private static bool ValidateUser(string username/*, string password, Enum country*/)
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
