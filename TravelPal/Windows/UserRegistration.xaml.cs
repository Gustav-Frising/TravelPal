using System.Windows;
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User newUser = new(txtUsername.Text, txtPassword.Text, (Country)cbLocation.SelectedIndex);

            bool isUserAdded = UserManager.AddUser(newUser);
            if (isUserAdded)
            {
                MessageBox.Show("user has been added succesufully");
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
