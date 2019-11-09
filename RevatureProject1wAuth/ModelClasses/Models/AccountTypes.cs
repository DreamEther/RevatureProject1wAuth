using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelClasses.Models
{
    public class AccountTypes
    {
        public int ID { get; set; }
    
        public string AccountType { get; set; }

        public decimal InterestRate { get; set; }
    
    }
}
