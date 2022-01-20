using System;
using System.Data.SqlClient;

namespace Bank.Users
{
    public class UserManager
    {
        private static UserManager userManager;
        private string connectionString;
        public static UserManager GetUserManager(string connectionString="")
        {
            return userManager != null ? userManager : (userManager = new UserManager(connectionString));
        }

        private UserManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public User Create(string name, string surname, string phone, 
            string login, string password, Accounts.Account account)
        {
            if (IsExists(login))
            {
                throw new Exception("User already exists");
            }
            User user = new User(name, surname, login, password, phone, account);

            SqlConnection connection = new SqlConnection(connectionString);
            string sql = $"INSERT INTO [Users] ([Name], [Surname], [Phone], [Login], [Password], [Account]) VALUES " +
                $"('{user.Name}', '{user.Surname}', '{user.Phone}', '{user.Login}', '{user.Password}', '{user.Account.AccountNumber}')";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            return user;
        }

        public bool IsExists(string login)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = $"SELECT * FROM [Users] WHERE [Login] = '{login}'";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            bool hasRows = reader.HasRows;
            reader.Close();
            connection.Close();

            return hasRows;
        }

        public void Clear()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string sql = $"DELETE FROM [Users]";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public User Get(string login)
        {
            if (!IsExists(login))
            {
                throw new Exception("User does not exists");
            }

            SqlConnection connection = new SqlConnection(connectionString);

            string sql = $"SELECT [Name], [Surname], [Phone], [Login], [Password], [AccountNumber], [Money] FROM [Users] " +
                $"JOIN [Accounts] ON [Accounts].[AccountNumber] = [Users].[Account] " +
                $"WHERE [Login] = '{login}'";

            SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();

            string name = reader.GetString(0);
            string surname = reader.GetString(1);
            string phone = reader.GetString(2);
            login = reader.GetString(3);
            string password = reader.GetString(4);
            int accountNumber = reader.GetInt32(5);
            uint money = (uint)reader.GetInt32(6);
            
            reader.Close();
            connection.Close();

            User u = new User(name, surname, login, password, phone, new Accounts.Account(accountNumber, money));

            return u;
            
        }

    }
}
