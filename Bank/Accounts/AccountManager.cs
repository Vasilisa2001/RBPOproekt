using System;
using System.Data.SqlClient;

namespace Bank.Accounts
{
    public class AccountManager
    {
        private static AccountManager accountManager;

        private string connectionString;
        public static AccountManager GetAccountManager(string connectionString = "")
        {
            return accountManager == null ? (accountManager = new AccountManager(connectionString)) : accountManager;
        }

        private AccountManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Account Create()
        {
            int accountNumber = GenerateAccountNumber();
            Account account = new Account(accountNumber, 0);

            SqlConnection connection = new SqlConnection(connectionString);
            string sql = $"INSERT INTO [Accounts] ([AccountNumber]) VALUES('{accountNumber}')";

            SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            return account;
        }

        public Account Get(int accountNumber)
        {
            if (!IsExists(accountNumber))
            {
                throw new Exception("Account does not exists");
            }
            
            SqlConnection connection = new SqlConnection(connectionString);

            string sql = $"SELECT * FROM [Accounts] WHERE [AccountNumber] = '{accountNumber}'";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            reader.Read();

            Account account = new Account(accountNumber, Convert.ToUInt32(reader[1].ToString()));

            reader.Close();
            connection.Close();

            return account;
        }

        public void Replenishment(int accountNumber, uint money)
        {
            if (!IsExists(accountNumber))
            {
                throw new Exception("Account does not exists");
            }

            SqlConnection connection = new SqlConnection(connectionString);

            string sql = $"UPDATE [Accounts] SET [Money] = [Money] + {money} WHERE [AccountNumber] = {accountNumber}";
            SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Withdrawal(int accountNumber, uint money)
        {
            if (!IsExists(accountNumber))
            {
                throw new Exception("Account does not exists");
            }

            Account account = Get(accountNumber);
            if (account.Money < money)
            {
                throw new Exception("Not enouth money");
            }

            SqlConnection connection = new SqlConnection(connectionString);

            string sql = $"UPDATE [Accounts] SET [Money] = [Money] - {money} WHERE [AccountNumber] = {accountNumber}";
            SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

        }

        public void Transfer(int accountNumberFrom, int accountNumberTo, uint money)
        {
            if (!IsExists(accountNumberFrom) || !IsExists(accountNumberTo))
            {
                throw new Exception("Account does not exists");
            }

            Withdrawal(accountNumberFrom, money);
            Replenishment(accountNumberTo, money);
        }

        public void Clear()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = "DELETE FROM [Accounts]";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        private int GenerateAccountNumber()
        {
            Random r = new Random();
            string generatedAccountNumber = string.Empty;

            do
            {
                generatedAccountNumber = string.Empty;
                for (int i = 0; i < 5; i++)
                {
                    generatedAccountNumber += r.Next(11).ToString();
                }
                
            } while (IsExists(generatedAccountNumber));

            return Convert.ToInt32(generatedAccountNumber);
        }

        public bool IsExists(int accountNumber)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = $"SELECT * FROM [Accounts] WHERE [AccountNumber] = '{accountNumber}'";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            bool hasRows = reader.HasRows;
            reader.Close();
            connection.Close();

            return hasRows;
        }

        private bool IsExists(string accountNumber)
        {
            return IsExists(Convert.ToInt32(accountNumber));
        }

    }
}
