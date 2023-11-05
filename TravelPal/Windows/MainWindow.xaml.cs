using System.Windows;
using TravelPal.Managers;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //sign in with usermanager
        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;


            bool isSuccessfulSignIn = UserManager.SignInUser(username, password);

            // if successful open travels
            if (isSuccessfulSignIn)
            {
                Travels TravelsWindow = new();
                TravelsWindow.Show();
                Close();
            }
            else
            {

                MessageBox.Show("Invalid username or password!, Warning");
            }
        }

        //register user
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserRegistration userRegistrationWindow = new();
            userRegistrationWindow.Show();
            Close();
        }
    }
}
