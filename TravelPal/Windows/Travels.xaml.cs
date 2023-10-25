using System.Windows;
using TravelPal.Managers;

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
            TravelDetails travelDetailsWindow = new();
            travelDetailsWindow.Show();

            Close();
        }
    }
}
