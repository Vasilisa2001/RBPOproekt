using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Bank;

namespace BankWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string login = loginTextBox.Text.Trim();
            string password = passTextBox.Text.Trim();
            string firstName = firstNameTextBox.Text.Trim();
            string secondName = secondNameTextBox.Text.Trim();
            string phone = phoneTextBox.Text.Trim();

            if(login == "" || password == "" || firstName == "" || secondName == "")
            {
                MessageBox.Show("Text box is empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!IsCorrectPhoneNumber(phone))
            {
                MessageBox.Show("Phone number is invalid", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                BankManager bankManager = BankManager.GetBankManager();
                try
                {
                    bankManager.CreateUser(firstName, secondName, phone, login, password);
                    NavigationService.GoBack();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private bool IsCorrectPhoneNumber(string phone)
        {
            if(phone.Length != 11)
            {
                return false;
            }

            for(int i = 0; i < phone.Length; i++)
            {
                if (!Char.IsDigit(phone[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private void phoneTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
