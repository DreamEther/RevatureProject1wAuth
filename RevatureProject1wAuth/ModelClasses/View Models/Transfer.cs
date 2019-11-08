using ModelClasses.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClasses.View_Models
{
    public class Transfer
    {
        public decimal _transferAmount;
        public string transferFrom = "Transfer From:";
        public string transferTo = "Transfer To:";
        public List<Account> accounts = new List<Account>();
        //public Transfer(Account account1, Account account2, decimal withdrawalAmount)
        //{
        //    _transferAmount = withdrawalAmount;
        //    account1.Balance -= _transferAmount;
        //    account2.Balance += _transferAmount;
        //}
    }
}
