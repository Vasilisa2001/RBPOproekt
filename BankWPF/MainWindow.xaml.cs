using System.Windows;
using BankWPF.Pages;
using Bank;

namespace BankWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string connectionString =
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Рабочий стол\3 КУРС\РБПО\BankWPF\Bank\Database1.mdf;Integrated Security=True";
            BankManager bankManager = BankManager.GetBankManager(connectionString);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new LoginPage());
        }
    }
}
