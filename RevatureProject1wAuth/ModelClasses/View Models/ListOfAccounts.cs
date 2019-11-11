using ModelClasses.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelClasses.View_Models
{
    public class ListOfAccounts
    {
        public List<Account> accounts = new List<Account>();

        //[Display(Name = "Created on:")]
        //public DateTime DateTime { get; set; }
        //public decimal InterestRate { get; set; }
        public Account Account { get; set; }


    }
}
