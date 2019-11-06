using ModelClasses.View_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelClasses.Models
{
    public class CheckingAccount 
    {
        public int ID { get; set; }
        public string AccountType { get; set; }


        public string CustomerID { get; set; }

        public decimal Balance { get; set; }

        public decimal InterestRate { get; set; }
        public List<Transaction> Transactions { get; set; }

        public Customer Customer { get; set; }
    }
}
