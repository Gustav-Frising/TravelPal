using System.Windows;
using TravelPal.Models.Travels;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelDetails.xaml
    /// </summary>
    public partial class TravelDetails : Window
    {

        //show details depending on what type of travel it is
        public TravelDetails(WorkTrip workTrip)
        {
            InitializeComponent();

            foreach (var packinglistitem in workTrip.Packinglist)
            {
                lstPackinglist.Items.Add(packinglistitem.GetInfo());
            }

            txtCity.Text = workTrip.Destination;
            txtCountry.Text = workTrip.Countries.ToString();
            txtTravellers.Text = workTrip.Travellers.ToString();
            txtTravelPurpose.Text = "Work trip";
            txtTravelSpecifics.Text = workTrip.MeetingDetails;


        }
        public TravelDetails(Vacation vacation)
        {
            InitializeComponent();
            foreach (var packinglistitem in vacation.Packinglist)
            {
                lstPackinglist.Items.Add(packinglistitem.GetInfo());
            }

            txtCity.Text = vacation.Destination;
            txtCountry.Text = vacation.Countries.ToString();
            txtTravellers.Text = vacation.Travellers.ToString();
            txtTravelPurpose.Text = "Vacation";
            if (vacation.AllInclusive == true)
            {
                txtTravelSpecifics.Text = "All inclusive";
            }
            else
            {
                txtTravelSpecifics.Text = "";
            }
            lstPackinglist.Tag = vacation.Packinglist;

        }
        public TravelDetails(Travel travel)
        {
            InitializeComponent();

            foreach (var packinglistitem in travel.Packinglist)
            {
                lstPackinglist.Items.Add(packinglistitem.GetInfo());
            }

            txtCity.Text = travel.Destination;
            txtCountry.Text = travel.Countries.ToString();
            txtTravellers.Text = travel.Travellers.ToString();
            lstPackinglist.Tag = travel.Packinglist;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Travels travelWindow = new();
            travelWindow.Show();

            Close();
        }
    }
}
