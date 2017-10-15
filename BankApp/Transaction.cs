using System;
namespace BankApp
{
    public enum TransactionType
    {
        Credit,
        Debit
    }
    public class Transaction
    {
        [Key] // remember to add data annotation!
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public TransactionType TypeOfTransaction { get; set; }

        [ForeignKey("Account")]
        public int AccountNumber { get; set; }

         public virtual Account Account
        {
            get;
            set;
        }
    }
}
