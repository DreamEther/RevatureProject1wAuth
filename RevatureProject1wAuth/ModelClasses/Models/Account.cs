using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelClasses.Models
{
    public abstract class Account
    {
        public int ID { get; set; }
        [NotMapped]
        public string AccountTypeAsString { get; set; }
        public string CustomerID { get; set; }

        public decimal Balance { get; set; }

        public DateTime DateTime { get; set; }
        public bool IsClosed { get; set; }
        [Display(Name = "AccountType")]
        public int AccountTypesID { get; set; }
       
        // [NotMapped]
        public decimal InterestRate { get; set; }
        public List<Transaction> Transactions { get; set; }

        public AccountTypes AccountType { get; set; }


    }
}
