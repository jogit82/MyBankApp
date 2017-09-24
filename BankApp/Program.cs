using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var account = new Account();
            account.EmailAddress = "test@gmail.com";
            account.AccountType = "Savings";

            var newBalance = account.Deposit(100);
            Console.WriteLine($"AccountNumber: {account.AccountNumber}, Email Address: {account.EmailAddress}, Balance: {account.Balance:C}, Account Type: {account.AccountType}");

            var account2 = new Account();
			account2.EmailAddress = "test2@gmail.com";
			account2.AccountType = "Checking";
            var newBalance2 = account2.Deposit(500);
            Console.WriteLine($"AccountNumber: {account2.AccountNumber}, Email Address: {account2.EmailAddress}, Balance: {account2.Balance:C}, Account Type: {account2.AccountType}");
        }
    }
}
