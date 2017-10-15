﻿using System;
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
            Console.WriteLine("*********************");
            Console.WriteLine("Welcome to my bank.");
            Console.WriteLine("*********************");
            while (true)
            {
                Console.WriteLine("Please choose an option below");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Create an account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Print all accounts");
                Console.WriteLine("5. Print all transactions");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "0":
                        return;
                    case "1":
                        Console.Write("Email address: ");
                        var emailAddress = Console.ReadLine();
                        Console.WriteLine("Account type: ");
                        var accountTypes = Enum.GetNames(typeof(TypeOfAccount));
                        for (var i = 0; i < accountTypes.Length; i++)
                        {
                            Console.WriteLine($"{i}. {accountTypes[i]}");
                        }
                        var accountType = (TypeOfAccount)Enum.Parse(typeof(TypeOfAccount), Console.ReadLine());
                        Console.Write("Amount to deposit: ");
                        var amount = Convert.ToDecimal(Console.ReadLine());
                        var account = Bank.CreateAccount(emailAddress, accountType, amount);
                        Console.WriteLine($"AccountNumber: {account.AccountNumber}, Email Address: {account.EmailAddress}, Balance: {account.Balance:C}, Account Type: {account.AccountType}. Created Date: {account.CreatedDate}");
                        break;
                    case "2":
                        PrintAllAccounts();
                        Console.Write("Account Number: ");
                        var accountNumber = Convert.ToInt32(Console.ReadLine());
						Console.Write("Amount to deposit: ");
						amount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Deposit(accountNumber, amount);
                        Console.WriteLine("Deposit was successful.");
                        break;
                    case "3":
						PrintAllAccounts();
						Console.Write("Account Number: ");
						accountNumber = Convert.ToInt32(Console.ReadLine());
						Console.Write("Amount to withdraw: ");
						amount = Convert.ToDecimal(Console.ReadLine());
						Bank.Withdraw(accountNumber, amount);
						Console.WriteLine("Withdrawal was successful.");
                        break;
                    case "4":
                        PrintAllAccounts();
                        break;
                    case "5":
                        PrintAllAccounts();
						Console.Write("Account Number: ");
						accountNumber = Convert.ToInt32(Console.ReadLine());
                        var transactions = Bank.GetAllTransactions(accountNumber);
                        foreach(var trans in transactions) 
                        {
                            Console.WriteLine($"Id: {trans.TransactionId}, Date: {trans.TypeOfTransaction}, Amount: {trans.Amount:C}, Description: {trans.Description}");
                        }
                        break;
                    default:
                        break;
                }
            }
        
        }

        private static void PrintAllAccounts()
        {
            Console.WriteLine("Email Address");
            var emailAddress = Console.ReadLine();
            var accounts = Bank.GetAllAccounts();
            foreach (var item in accounts)
            {
                Console.WriteLine($"AccountNumber: {item.AccountNumber}, Email Address: {item.EmailAddress}, Balance: {item.Balance:C}, Account Type: {item.AccountType}. Created Date: {item.CreatedDate}");
            }
        }
    }
}
