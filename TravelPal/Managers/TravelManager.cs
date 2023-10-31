using System.Windows.Controls;
using TravelPal.Models.Travels;
using TravelPal.Models.Users;

namespace TravelPal.Managers
{
    public static class TravelManager
    {
        //public static List<Travel> Traveles { get; set; }
        public static void AddTravel(Travel travel)
        {
            User user = (User)UserManager.SignedInUser;
            user.Travels.Add(travel);

        }
        public static void RemoveTravel(ListView view)
        {
            User user = new();
            ListViewItem selectedItem = (ListViewItem)view.SelectedItem;
            view.Items.Remove(selectedItem);
            Travel travel = (Travel)selectedItem.Tag;

            if (UserManager.SignedInUser.GetType() == typeof(User))
            {
                user = (User)UserManager.SignedInUser;
                user.Travels.Remove(travel);
            }
            else
            {
                foreach (IUser users in UserManager.Users)
                {
                    if (users.GetType() == typeof(User))
                    {
                        User usertoremove = (User)users;
                        Travel selectedtravel = (Travel)selectedItem.Tag;
                        usertoremove.Travels.Remove(selectedtravel);
                    }
                }
            }

        }
        static public void GetAllTravels(ListView view)
        {
            User user = new();
            foreach (IUser newUser in UserManager.Users)
            {
                if (newUser.GetType() == typeof(Admin))
                {
                    continue;
                }
                user = (User)newUser;
                foreach (Travel travel in user.Travels)
                {
                    ListViewItem item = new();
                    item.Content = travel.GetInfo();
                    item.Tag = travel;
                    view.Items.Add(item);
                }

            }

        }
    }
}
