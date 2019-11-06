using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelClasses.Models
{
    public class Transaction
    {
        public int ID { get; set; }
        [ForeignKey("AccountID")]
        public int AccountID { get; set; }
        public decimal TransactionAmount { get; set; }

        public DateTime DateTime { get; set; }

        public decimal Balance { get; set; }

        public Transaction() //why do i need this???
        {

        }
        public Transaction(int id, decimal balance, decimal transactionAmount, DateTime dateTime)
        {
            AccountID = id;
            Balance = balance;
            TransactionAmount = transactionAmount;
            DateTime = dateTime;
        }

    }
}
