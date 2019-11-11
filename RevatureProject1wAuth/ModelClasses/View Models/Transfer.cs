using ModelClasses.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelClasses.View_Models
{
    public class Transfer
    {
        public decimal TransferAmount { get; set; }

        [Display(Name = "Account ID you are transferring from:")]
        public int TransferFrom { get; set; }

        [Display(Name = "Account ID you are transferring to:")]

        public int TransferTo { get; set; }

        public List<Account> accounts = new List<Account>();
        //public Transfer(Account account1, Account account2, decimal withdrawalAmount)
        //{
        //    _transferAmount = withdrawalAmount;
        //    account1.Balance -= _transferAmount;
        //    account2.Balance += _transferAmount;
        //}
    }
}
