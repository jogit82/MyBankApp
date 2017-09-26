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

            var account = Bank.CreateAccount("test@gmail.com");
            Console.WriteLine($"AccountNumber: {account.AccountNumber}, Email Address: {account.EmailAddress}, Balance: {account.Balance:C}, Account Type: {account.AccountType}");

            var account2 = Bank.CreateAccount("test2@gmail.com", TypeOfAccount.Savings, initialDeposit: 500);
            Console.WriteLine($"AccountNumber: {account2.AccountNumber}, Email Address: {account2.EmailAddress}, Balance: {account2.Balance:C}, Account Type: {account2.AccountType}");
        }
    }
}
