using System;
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
            User user = (User)UserManager.SignedInUser;
            List<Travel> travels = user.Travels;


            InitializeComponent();

            // visa username och land
            lblUsername.Content = UserManager.SignedInUser.Username;
            lblCountry.Content = UserManager.SignedInUser.Location;
            try
            {

                foreach (var travel in travels)
                {
                    ListViewItem item = new();
                    item.Content = travel.GetInfo();
                    item.Tag = travel;
                    lstTravels.Items.Add(item);
                }
            }
            catch (NullReferenceException e)
            {
                MessageBox.Show(e.Message);
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            // Hämta det selectade item:et i listan
            ListViewItem selectedItem = (ListViewItem)lstTravels.SelectedItem;

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

        }
    }
}
