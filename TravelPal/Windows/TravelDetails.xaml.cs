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


            txtCity.Text = workTrip.Destination;
            txtCountry.Text = workTrip.Countries.ToString();
            txtTravellers.Text = workTrip.Travellers.ToString();
            txtTravelPurpose.Text = workTrip.MeetingDetails;

        }
        public TravelDetails(Vacation vacation)
        {
            InitializeComponent();

            txtCity.Text = vacation.Destination;
            txtCountry.Text = vacation.Countries.ToString();
            txtTravellers.Text = vacation.Travellers.ToString();
            if (vacation.AllInclusive == true)
            {
                txtTravelPurpose.Text = "All inclusive";
            }
            else
            {
                txtTravelPurpose.Text = "";
            }

        }

    }
}
