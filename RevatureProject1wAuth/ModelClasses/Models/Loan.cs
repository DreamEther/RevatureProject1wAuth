using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClasses.Models
{
    public class Loan : Account
    {
        public Loan()
        {
            AccountTypeAsString = "Loan";
            Balance = 0;
            InterestRate = 4;
           // AccountTypesID = 3;
        }
    }
}
