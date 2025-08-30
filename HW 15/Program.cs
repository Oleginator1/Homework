using Exercise.H15;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Threading;
using System.Transactions;

namespace Exercise
{

    class Program
    {
         static List<BankAccount> BankAccounts = new List<BankAccount>();


        static void ShowMenu()
        {
            Console.WriteLine("\n--- BANK MENU ---");
            Console.WriteLine("1 - Create a new account");
            Console.WriteLine("2 - View account details");
            Console.WriteLine("3 - Deposit money");
            Console.WriteLine("4 - Withdraw money");
            Console.WriteLine("5 - Exit");
            Console.Write("Choose: ");
        }

        static void CreateAccount()
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the currency you want for your account (EUR/USD):");
            string currencystr = Console.ReadLine();

            if(!Enum.TryParse(currencystr, true, out Currency currency))
            {
                Console.WriteLine("Invalid currency.");
                return;
            }

            var account = new BankAccount(name, currency);
            BankAccounts.Add(account);
            Console.WriteLine($"Account created successfully!");
            Console.WriteLine($"Account number: {account.accountNumber}");
            Console.WriteLine($"PIN: {account.RevealPin()}");
            Console.ReadLine();
        }


        static void ViewAccount()
        {          

            BankAccount account = FindAccount();

            if (account == null) return;
            
            Console.WriteLine(account);


            var transactions = account.GetTransactionHistory().ToList();
            if (!transactions.Any())
            {
                Console.WriteLine("No transactions yet.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Transactions:");
                foreach (var tx in transactions)
                {
                    Console.WriteLine(tx);
                }
                Console.ReadLine();
            }

        }

        static BankAccount FindAccount()
        {
            if (!BankAccounts.Any())
            {
                Console.WriteLine("No accounts exist yet.");
                Console.ReadLine();
                return null;
            }

            Console.WriteLine("Enter your account number: ");
            if (!long.TryParse(Console.ReadLine(), out long accNum))
            {
                Console.WriteLine("Invalid account number.");
                Console.ReadLine();
                return null;
            }

            foreach (BankAccount account in BankAccounts)
            {
                if (account.accountNumber == accNum)
                {
                    return account;
                }

            }
            return null;
        }

        static void Deposit_Withdraw(char operation)
        {

            BankAccount account = FindAccount();
            if (account == null) return;
            
            if (operation != 'd' && operation != 'w')
            {
                Console.WriteLine("Wrong operation");
                return;
            }
                

            Console.WriteLine("Enter your PIN: ");
            string PIN = Console.ReadLine();

            Console.WriteLine("Enter the amount:");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                Console.WriteLine("Invalid amount.");
                Console.ReadLine();
                return;
            }

            bool success = false;

            if (operation == 'd')
            {                
                success = account.Deposit(PIN, amount);
            }
            else if (operation == 'w')
            {
                success = account.Withdrawal(PIN, amount);
            }


            if (success)
            {
                Console.WriteLine("Transaction successful.");
            }
            else
            {
                Console.WriteLine("Transaction failed. Check your PIN or balance.");
            }

            Console.ReadLine();

        }


        static BankAccount Check_If_Account_Exists(int accountNumber)
        {
            foreach(BankAccount account in BankAccounts)
            {
                if (account.accountNumber == accountNumber)
                {                    
                    return account;
                }
               
            }            
            return null;
            
        }

        static void Main()
        {
            
            BankAccount account = null;
            while (true)
            {
                Console.Clear();
                ShowMenu();

                if (!int.TryParse(Console.ReadLine(), out int opt))
                {
                    Console.WriteLine("Invalid input. Try again.");
                    continue;
                }


                switch (opt)
                {
                    case 1: CreateAccount(); 
                        break;

                    case 2: ViewAccount(); 
                        break;                       

                    case 3:
                          
                        Deposit_Withdraw('d');     
                        Console.ReadLine();
                        break;

                    case 4:
                        Deposit_Withdraw('w');
                        Console.ReadLine();
                        break;

                    case 5:
                        System.Environment.Exit(0);
                        break;

                    default: Console.WriteLine("Wrong option");
                        break;

                }
               
            }
            

        }


    }
}
