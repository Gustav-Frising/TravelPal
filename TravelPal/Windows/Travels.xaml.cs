using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TravelPal.Managers;
using TravelPal.Models.Travels;
using TravelPal.Models.Users;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for Travels.xaml
    /// </summary>
    public partial class Travels : Window
    {


        public Travels()
        {
            InitializeComponent();

            // Show username & country  
            lblUsername.Content = UserManager.SignedInUser.Username;
            lblCountry.Content = UserManager.SignedInUser.Location;

            // If admin load listview with all travels else load users travels
            if (UserManager.SignedInUser.GetType() == typeof(Admin))
            {
                btnAddTravel.Visibility = Visibility.Hidden;
                TravelManager.GetAllTravels(lstTravels);
            }
            else
            {
                User user = (User)UserManager.SignedInUser;
                List<Travel> travels = user.Travels;
                foreach (var travel in travels)
                {
                    ListViewItem item = new();
                    item.Content = travel.GetInfo();
                    item.Tag = travel;
                    lstTravels.Items.Add(item);
                }
            }




        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserManager.SignOutUser();


            MainWindow mainwindow = new();
            mainwindow.Show();

            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddTravel addTravelWindow = new();
            addTravelWindow.Show();

            Close();
        }

        // Travel details
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if ((ListViewItem)lstTravels.SelectedItem != null)
            {

                ListViewItem selectedItem = (ListViewItem)lstTravels.SelectedItem;

                //check which type of travel it is and send it to traveldetailsWindow
                if (selectedItem.Tag.GetType() == typeof(Vacation))
                {

                    TravelDetails travelDetailsWindow = new((Vacation)selectedItem.Tag);
                    travelDetailsWindow.Show();

                    Close();
                }
                else if (selectedItem.Tag.GetType() == typeof(WorkTrip))
                {
                    TravelDetails travelDetailsWindow = new((WorkTrip)selectedItem.Tag);
                    travelDetailsWindow.Show();
                    Close();
                }
                else
                {
                    TravelDetails travelDetailsWindow = new((Travel)selectedItem.Tag);
                    travelDetailsWindow.Show();
                    Close();
                }
            }
            else
            {
                MessageBox.Show("you must choose a list to view");
            }
        }
        //Remove travel
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if ((ListViewItem)lstTravels.SelectedItem != null)
            {
                TravelManager.RemoveTravel(lstTravels);
            }
            else
            {
                MessageBox.Show("you must select an item, to remove");
            }
        }
    }
}
