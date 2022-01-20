using System;
using System.Windows;
using System.Windows.Controls;
using Bank;
using Bank.Users;


namespace BankWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для PersonalAccountPage.xaml
    /// </summary>
    public partial class PersonalAccountPage : Page
    {
        private string login;
        public PersonalAccountPage(string login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ReloadUserData();
        }


        private void ReloadUserData()
        {
            BankManager bankManager = BankManager.GetBankManager();

            User user = bankManager.GetUser(login);

            firstNameSecondNameLabel.Content = user.Surname + " " + user.Name;
            accountNumberLabel.Content = user.Account.AccountNumber;
            moneyLabel.Content = user.Account.Money;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                uint money = Convert.ToUInt32(getMoneyTextBox.Text);

                BankManager bankManager = BankManager.GetBankManager();

                bankManager.Replenishment(login, money);

                ReloadUserData();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BankManager bankManager = BankManager.GetBankManager();
            try
            {
                string loginTo = loginSendTextBox.Text;
                uint money = Convert.ToUInt32(moneySendTextBox.Text);
                bankManager.Transfer(login, loginTo, money);
                ReloadUserData();
                MessageBox.Show("Complited", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
