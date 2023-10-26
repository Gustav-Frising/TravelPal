using System;
using System.Windows;
using System.Windows.Controls;
using TravelPal.Enums;
using TravelPal.Managers;
using TravelPal.Models.Travels;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for AddTravel.xaml
    /// </summary>
    public partial class AddTravel : Window
    {
        public AddTravel()
        {
            InitializeComponent();


            foreach (Purpose purpose in Enum.GetValues(typeof(Purpose)))
            {
                ListViewItem item = new();
                item.Content = purpose.ToString();
                item.Tag = purpose;
                CbTravelPurpose.Items.Add(item);
            }

            cbLocation.Items.Add(" - - Select Country - -");

            foreach (Country country in Enum.GetValues(typeof(Country)))
            {
                //Lägg till i combo box
                ListViewItem item = new();

                item.Content = country.ToString();
                item.Tag = country;
                cbLocation.Items.Add(item);
            }

            cbLocation.SelectedIndex = 0;
        }


        private void CbTravelPurpose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            if (CbTravelPurpose.SelectedIndex == 0)
            {
                lblAllInclusive.Visibility = Visibility.Visible;
                cbAllInclusive.Visibility = Visibility.Visible;
            }
            else
            {
                lblAllInclusive.Visibility = Visibility.Hidden;
                cbAllInclusive.Visibility = Visibility.Hidden;
            }

            if (CbTravelPurpose.SelectedIndex == 1)
            {
                lblMeetingDetails.Visibility = Visibility.Visible;
                txtMeetingDetails.Visibility = Visibility.Visible;
            }
            else
            {
                lblMeetingDetails.Visibility = Visibility.Hidden;
                txtMeetingDetails.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Travel newTravel = new(txtCity.Text, (Country)cbLocation.SelectedIndex, int.Parse(txtTravelers.Text));

            TravelManager.AddTravel(newTravel);

            Travels travelsWindow = new();
            travelsWindow.Show();

            Close();
        }
    }
}
