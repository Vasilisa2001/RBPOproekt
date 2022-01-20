using Bank.Users;

namespace Bank.Accounts
{
    public class Account
    {
        public int AccountNumber { get; private set; }
        public uint Money { get; private set; }

        public Account(int accountNumber, uint money)
        {
            AccountNumber = accountNumber;
            Money = money;
        }
    }
}
