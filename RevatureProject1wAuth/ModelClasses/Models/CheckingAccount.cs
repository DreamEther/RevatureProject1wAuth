using DataAnnotationsExtensions;
using ModelClasses.View_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelClasses.Models
{
    public class CheckingAccount : Account
    {
        public CheckingAccount()
        {
            AccountType = "Checking";
            Balance = 0;
            InterestRate = 5;
        }
    }
}
