using NUnit.Framework;
using Bank;
namespace BankTest
{
    public class Tests
    {
        private string testConnectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bauro\source\repos\gruppa\BankWPF\Bank\TestDB.mdf;Integrated Security=True";
        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void TearDown()
        {
            BankManager bankManager = BankManager.GetBankManager(testConnectionString);
            bankManager.ClearUsers();
            bankManager.ClearAccounts();
        }

        [Test]
        public void CreatingAccounts()
        {
            BankManager bankManager = BankManager.GetBankManager(testConnectionString);

            Assert.IsFalse(bankManager.IsExistsAccount(12345));

            int accountNumber = bankManager.CreateAccount().AccountNumber;

            Assert.IsTrue(bankManager.IsExistsAccount(accountNumber));
        }

        [Test]
        public void CreatingUsers()
        {
            BankManager bankManager = BankManager.GetBankManager(testConnectionString);
            Assert.IsFalse(bankManager.IsExistsUser("login"));

            int accountNumber = bankManager.CreateUser("Ivan", "Ivanov", "89969428558", "login", "pass")
                .Account
                .AccountNumber;

            Assert.IsTrue(bankManager.IsExistsUser("login"));
            Assert.IsTrue(bankManager.IsExistsAccount(accountNumber));

            Assert.Catch(() =>
            {
                bankManager.CreateUser("Ivan", "Ivanov", "89969428558", "login", "pass");
            });
        }

        [Test]
        public void AddMoneyToAccount()
        {
            BankManager bankManager = BankManager.GetBankManager(testConnectionString);
            bankManager.CreateUser("Ivan", "Ivanov", "89969428558", "login", "pass");

            Assert.AreEqual(0, bankManager.GetUserMoney("login"));
            bankManager.Replenishment("login", 200);
            Assert.AreEqual(200, bankManager.GetUserMoney("login"));
        }

        [Test]
        public void RemoveMoneyFromAccount()
        {
            BankManager bankManager = BankManager.GetBankManager(testConnectionString);
            bankManager.CreateUser("Ivan", "Ivanov", "89969428558", "login", "pass");
            bankManager.Replenishment("login", 100);
            
            bankManager.Withdrawal("login", 50);
            Assert.AreEqual(50, bankManager.GetUserMoney("login"));

            bankManager.Withdrawal("login", 1);
            Assert.AreEqual(49, bankManager.GetUserMoney("login"));

            Assert.Catch(() =>
            {
                bankManager.Withdrawal("login", 1000);
            });
        }

        [Test]
        public void TransferMoney()
        {
            BankManager bankManager = BankManager.GetBankManager(testConnectionString);
            bankManager.CreateUser("Ivan", "Ivanov", "89969428558", "login1", "pass");
            bankManager.CreateUser("Oleg", "Ivanov", "89969428558", "login2", "pass");

            bankManager.Replenishment("login1", 1000);
            bankManager.Transfer("login1", "login2", 300);

            Assert.AreEqual(700, bankManager.GetUserMoney("login1"));
            Assert.AreEqual(300, bankManager.GetUserMoney("login2"));
        }
    }
}