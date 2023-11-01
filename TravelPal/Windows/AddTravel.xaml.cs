using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TravelPal.Enums;
using TravelPal.Managers;
using TravelPal.Models.PackingListItems;
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





            if (Enum.IsDefined(typeof(Country), UserManager.SignedInUser.Location.ToString()) && !Enum.IsDefined(typeof(EuropeanCountry), UserManager.SignedInUser.Location.ToString()))
            {

                TravelDocument newTravelDocument = new("Passport", true);
                ListViewItem item = new();
                item.Content = newTravelDocument.GetInfo();
                item.Tag = newTravelDocument;
                lstPackingList.Items.Add(item);
            }

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
                ComboBoxItem item = new();

                item.Content = country.ToString();
                item.Tag = country;
                cbLocation.Items.Add(item);
            }

            cbLocation.SelectedIndex = 0;
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<IPackingListItem> packingList = new();

            foreach (ListViewItem item in lstPackingList.Items)
            {
                packingList.Add((IPackingListItem)item.Tag);
            }

            if (CbTravelPurpose.SelectedIndex == 1)
            {
                WorkTrip newWorkTrip = new(txtCity.Text, (Country)cbLocation.SelectedIndex, int.Parse(txtTravelers.Text), packingList, txtMeetingDetails.Text);
                TravelManager.AddTravel(newWorkTrip);
            }
            else if (CbTravelPurpose.SelectedIndex == 0)
            {

                Vacation newVacation = new(txtCity.Text, (Country)cbLocation.SelectedIndex, int.Parse(txtTravelers.Text), packingList, (bool)cbAllInclusive.IsChecked);
                TravelManager.AddTravel(newVacation);
            }
            else
            {
                Travel newTravel = new(txtCity.Text, (Country)cbLocation.SelectedIndex, int.Parse(txtTravelers.Text), packingList);
                TravelManager.AddTravel(newTravel);
            }

            Travels travelsWindow = new();
            travelsWindow.Show();

            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (cbTravelDocument.IsChecked == true)
            {
                TravelDocument newTravelDocument = new(txtItem.Text, (bool)cbRequired.IsChecked);
                ListViewItem item = new();
                item.Content = newTravelDocument.GetInfo();
                item.Tag = newTravelDocument;
                lstPackingList.Items.Add(item);
            }
            else
            {
                OtherItem newOtherItem = new(txtItem.Text, int.Parse(txtQuantity.Text));
                ListViewItem item = new();
                item.Content = newOtherItem.GetInfo();
                item.Tag = newOtherItem;
                lstPackingList.Items.Add(item);

            }

            txtItem.Text = "";
            txtQuantity.Text = "";
            cbTravelDocument.IsChecked = false;
            cbRequired.IsChecked = false;
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

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            cbRequired.Visibility = Visibility.Visible;
            lblRequired.Visibility = Visibility.Visible;
            txtQuantity.Visibility = Visibility.Hidden;
            lblQuantity.Visibility = Visibility.Hidden;
            txtQuantity.Text = "";
        }
        private void CheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            cbRequired.Visibility = Visibility.Hidden;
            lblRequired.Visibility = Visibility.Hidden;
            txtQuantity.Visibility = Visibility.Visible;
            lblQuantity.Visibility = Visibility.Visible;
        }
    }
}
