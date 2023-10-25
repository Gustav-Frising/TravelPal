using System;
using System.Windows;
using System.Windows.Controls;
using TravelPal.Enums;

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

            cbLocation.Items.Add(" - - Select prio - -");

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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
