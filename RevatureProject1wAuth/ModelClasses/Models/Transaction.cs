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
    }
}
