using System;
using System.Windows;
using System.Windows.Controls;
using TravelPal.Enums;
using TravelPal.Managers;
using TravelPal.Models.Users;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for UserRegistration.xaml
    /// </summary>
    public partial class UserRegistration : Window
    {
        public UserRegistration()
        {

            InitializeComponent();


            //Load combobox with enum
            cbLocation.Items.Add(" - - Select Country - -");

            foreach (Country country in Enum.GetValues(typeof(Country)))
            {

                ListViewItem item = new();

                item.Content = country.ToString();
                item.Tag = country;
                cbLocation.Items.Add(item);
            }

            cbLocation.SelectedIndex = 0;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //add user if requrements are met

            User newUser = new(txtUsername.Text, txtPassword.Text, (Country)cbLocation.SelectedIndex);

            bool isUserAdded = UserManager.AddUser(newUser);
            if (isUserAdded)
            {
                MessageBox.Show("user has been added sucessfully");
                MainWindow mainwindow = new();
                mainwindow.Show();

                Close();
            }
            else
            {
                MessageBox.Show("User could not be added");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new();
            mainwindow.Show();

            Close();
        }
    }
}
