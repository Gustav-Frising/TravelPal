﻿using System.Collections.Generic;
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
                        MeetingDetails = "Meeting on Friday at clarion Hotel",
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
            }
            //new User ("a", "a", Enums.Country.Sweden),

            //new Admin("admin", "password", Enums.Country.Sweden),
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
