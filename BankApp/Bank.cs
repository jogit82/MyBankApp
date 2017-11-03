using System;
using System.Collections.Generic;

namespace BankApp
{
    public static class Bank // static class, everything in here has to be static
    {
        // static -> we only want one list, and not a new copy everytime we create an account
        private static List<Account> accounts = new List<Account>();

        /// <summary>
        ///     This is about a bank account
        /// </summary>
        /// <returns>Returns the new account.</returns>
        /// <param name="emailAddress">Email address of the account.</param>
        /// <param name="accountType">Account type of the account.</param>
        /// <param name="initialDeposit">Initial deposit to deposit.</param>
        public static Account CreateAccount(string emailAddress, TypeOfAccount accountType = TypeOfAccount.Checking, decimal initialDeposit = 0)
        {
            //var account = new Account();
            //account.EmailAddress = emailAddress;
            //account.AccountType = accountType;

            var account = new Account
            {
                EmailAddress = emailAddress,
                AccountType = accountType
            };

            if (initialDeposit > 0)
            {
                account.Deposit(initialDeposit);
            }
            accounts.Add(account);
            return account;
        }

        public static List<Account> GetAllAccounts()
        {
            return accounts;
        }

        public static void Deposit(int accountNumber, decimal amount)
        {
            var account = db.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            if (account == null)
            {
                return;
                // TODO: exception handling
            }

            account.Deposit(amount);

            var transaction = new Transaction
            {
                TransactionDate = DateTime.UtcNow,
                TypeOfTransaction = TransactionType.Credit,
                Description = "Branch deposit",
                Amount = amount,
                AccountNumber = account.AccountNumber
            };

            db.Transactions.Add(transaction);
            db.SaveChanges();
        }

        public static void Withdraw(int accountNumber, decimal amount)
        {
            var account = db.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            if (account == null)
            {
                throw new ArgumentOutOfRangeException("Invalid account number.");

            }

            account.Withdraw(amount);

            var transaction = new Transaction
            {
                TransactionDate = DateTime.UtcNow,
                TypeOfTransaction = TransactionType.Debit,
                Description = "Branch withdraw",
                Amount = amount,
                AccountNumber = account.AccountNumber
            };

            db.Transactions.Add(transaction);
            db.SaveChanges();
        }

        public static List<Transaction> GetAllTransactions(int accountNumber)
        {
            return db.Transactions.Where(t => t.AccountNumber == accountNumber).OrderByDescending(t => t.TransactionDate).ToList();
        }
    }
}
