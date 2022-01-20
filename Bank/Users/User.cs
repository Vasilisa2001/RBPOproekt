using Bank.Accounts;

namespace Bank.Users
{
    public class User
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Phone { get; private set; }
        public Account Account { get; private set; }

        public User(string name, string surname, string login, string password, string phone, Account account)
        {
            Name = name;
            Surname = surname;
            Login = login;
            Password = password;
            Phone = phone;
            Account = account;
        }

        public override string ToString()
        {
            return $"{Name} {Surname} {Phone}: {Account}";
        }
    }
}
