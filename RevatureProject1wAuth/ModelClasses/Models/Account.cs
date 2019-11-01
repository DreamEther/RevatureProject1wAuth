using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClasses.Models
{
    public abstract class Account
    {
        public decimal WithdrawalAmount { get; set; }
        public double CustomerID { get; set; }
        public decimal DepositAmount { get; set; }
        public decimal InterestRate { get; set; }
        public string AccountType { get; set; }

        public string WithdrawalString { get; set; }

        public string DepositString { get; set; }
        //public List<Transaction> transactions = new List<Transaction>();
        public int AccountID { get; set; }
        public decimal Balance { get; set; }

        public DateTime DateOfTransaction { get; set; }
    }
}
