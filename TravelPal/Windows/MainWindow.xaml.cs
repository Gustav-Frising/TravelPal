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

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            //Använd usermanager för att logga in
            UserManager newUserManager = new();

            bool isSuccessfulSignIn = newUserManager.SignInUser(username, password);

            //lyckass inloggning öppna Travels
            if (isSuccessfulSignIn)
            {
                Travels TravelsWindow = new();
                TravelsWindow.Show();
                Close();
            }
            else
            {
                //misslyckas visa varningsmeddelande
                MessageBox.Show("Invalid username or password!, Warning");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserRegistration userRegistrationWindow = new();
            userRegistrationWindow.Show();
            Close();
        }
    }
}
