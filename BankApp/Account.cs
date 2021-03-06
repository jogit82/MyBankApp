﻿using System;
using System.Collections.Generic;

namespace BankApp
{
    public enum TypeOfAccount
    {
        Checking,
        Savings,
        Loan,
        CD
    }

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

        public TypeOfAccount AccountType
        { get; set; }

        public DateTime CreatedDate
        { get; set; }

        public virtual ICollection<Transaction> Transactions
        {
            get;
            set;
        }

		#endregion

		#region  Constructors
        public Account() 
        {
            AccountNumber = ++lastAccountNumber;
            CreatedDate = DateTime.UtcNow;
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
            if(amount > Balance) 
            {
                throw new ArgumentOutOfRangeException("Insufficient funds.");
            }

			Balance -= amount;
            return Balance;
		}

		#endregion
	}
}
