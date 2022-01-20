using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Bank;
using Bank.Users;

namespace BankWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BankManager bankManager = BankManager.GetBankManager();

            string login = loginTextBox.Text;
            string password = passPasswordBox.Password;

            try
            {
                User u = bankManager.GetUser(login);
                if(u.Password == password)
                {
                    NavigationService.Navigate(new PersonalAccountPage(u.Login)); 
                }
                else
                {
                    MessageBox.Show("Bad");
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navigation = this.NavigationService;
            navigation.Navigate(new RegistrationPage());
        }
    }
}
