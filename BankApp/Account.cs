using System;
namespace BankApp
{
    public class Account
    {
        private static int lastAccountNumber = 0;
        #region Properties
        /// <summary>
        /// This is about the account number
        /// </summary>
        public int AccountNumber
        { get; }

        /// <summary>
        /// This is about the email address of the user
        /// </summary>
        public string EmailAddress
        { get; set; }

        public decimal Balance
        { get; private set; }

        public string AccountType
        { get; set; }

        public DateTime CreatedDate
        { get; set; }

		#endregion

		#region  Constructors
        public Account() 
        {
            AccountNumber = ++lastAccountNumber;
        }
		#endregion

		#region Methods

        public decimal Deposit(decimal amount)
        {
            Balance += amount;
            return Balance;
        }

		public decimal Withdraw(decimal amount)
		{
			Balance -= amount;
            return Balance;
		}

		#endregion
	}
}
