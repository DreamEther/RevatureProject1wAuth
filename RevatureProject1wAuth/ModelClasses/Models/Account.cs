using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelClasses.Models
{
    public class Account
    {
        public int ID { get; set; }
        [NotMapped]
        public string AccountType { get; set; }
        public string CustomerID { get; set; }

        public decimal Balance { get; set; }

        public decimal InterestRate { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
