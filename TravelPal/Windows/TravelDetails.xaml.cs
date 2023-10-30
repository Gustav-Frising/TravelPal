using System.Windows;
using TravelPal.Models.Travels;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelDetails.xaml
    /// </summary>
    public partial class TravelDetails : Window
    {

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Travels travelWindow = new();
            travelWindow.Show();

            Close();
        }
    }
}
