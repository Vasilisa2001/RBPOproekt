using Bank.Accounts;
using Bank.Users;

namespace Bank
{
    public class BankManager
    {
        private static BankManager bankManager;

        private AccountManager accountManager;
        private UserManager userManager;

        public static BankManager GetBankManager(string connectionString="")
        {
            return bankManager == null ? (bankManager = new BankManager(connectionString)) : bankManager;
        }

        private BankManager(string connectionString)
        {
            accountManager = AccountManager.GetAccountManager(connectionString);
            userManager = UserManager.GetUserManager(connectionString);
        }

        public Account CreateAccount()
        {
            return accountManager.Create();
        }

        public bool IsExistsAccount(int accountNumber)
        {
            return accountManager.IsExists(accountNumber);
        }

        public void ClearAccounts()
        {
            accountManager.Clear();
        }

        public User CreateUser(string name, string surname, string phone,
            string login, string password)
        {
            Account account = CreateAccount();

            return userManager.Create(name, surname, phone, login, password, account);
        }

        public User GetUser(string login)
        {
            return userManager.Get(login);
        }

        public bool IsExistsUser(string login)
        {
            return userManager.IsExists(login);
        }

        public void ClearUsers()
        {
            userManager.Clear();
        }

        public void Replenishment(string login, uint money)
        {
            accountManager.Replenishment(userManager.Get(login).Account.AccountNumber, money);
        }

        public void Withdrawal(string login, uint money)
        {
            accountManager.Withdrawal(userManager.Get(login).Account.AccountNumber, money);
        }

        public void Transfer(string loginFrom, string loginTo, uint money)
        {
            accountManager.Transfer(userManager.Get(loginFrom).Account.AccountNumber,
                                    userManager.Get(loginTo).Account.AccountNumber,
                                    money);
        }

        public uint GetUserMoney(string login)
        {
            return GetUser(login).Account.Money;
        }
    }
}
