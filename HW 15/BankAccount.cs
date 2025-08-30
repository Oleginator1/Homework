using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.H15
{
    internal class Transaction
    {
        public DateTime Date { get; }
        public decimal Amount { get; }
        public string Type { get; }
        public Transaction(decimal amount, string type)
        {
            Date = DateTime.Now;
            Amount = amount;
            Type = type;
        }

        public override string ToString()
        {
            string status = Type.StartsWith("Failed") ? "[FAILED]" : "[SUCCESSFUL]";
            return $"{Date:G} | {Type,-15} | {Amount,10:0.00} {status}";
        }
    }


    public enum Currency
    {
        EUR,
        USD,
    }
    internal class BankAccount
    {
        private static Random rnd = new Random();

        private DateTime creationDate;
        private string OwnerName;
        static List<long> accountNumbers = new List<long>();
        public long accountNumber;
        private Currency currency;
        private string PIN;
        public bool pinRevealed = false;
        public decimal Balance { get; private set; }

        private  readonly List<Transaction> transactionHistory = new List<Transaction>();
         
        public BankAccount(string name, Currency currency)
        {
            creationDate = DateTime.Now;
            OwnerName = name;
            this.currency = currency;            

            PIN = rnd.Next(0, 1000).ToString("D4");

           if(accountNumbers?.Any() != true)
            {
                accountNumber = 1000000000;
                accountNumbers.Add(accountNumber);
            }
           else
            {
                accountNumber = accountNumbers.Last() + 1;
                accountNumbers.Add(accountNumber);
            }         

        }

        public string RevealPin()
        {
            if (!pinRevealed)
            {
                pinRevealed = true;
                return PIN;
            }

            return null;

        }

        public bool Deposit(string PIN, decimal amount)
        {
            if (PIN != this.PIN || amount <= 0)
            {
                transactionHistory.Add(new Transaction(amount, "FailedDeposit"));
                return false;
            }

            Balance += amount;
            transactionHistory.Add(new Transaction(amount, "Deposit"));
            return true;
        }

        public bool Withdrawal(string PIN, decimal amount)
        {
            if (PIN != this.PIN || amount <= 0 || amount > Balance)
            {
                transactionHistory.Add(new Transaction(-amount, "FailedWithdrawal"));
                return false;
            }

            Balance -= amount;
            transactionHistory.Add(new Transaction(-amount, "Deposit"));
            return true;
        }

        public IEnumerable<Transaction> GetTransactionHistory() => transactionHistory;

        public override string ToString()
        {
            return $"Account {accountNumber} | Owner: {OwnerName} | Balance: {Balance:0.00} {currency}";
        }



    }
}
