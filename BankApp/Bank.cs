using System;
namespace BankApp
{
    public static class Bank
    {
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
            return account;
        }
    }
}
