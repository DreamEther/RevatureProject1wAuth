using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClasses.Models
{
    public class Loan : Account
    {
        public Loan()
        {
            AccountType = "Loan";
            Balance = 0;
            InterestRate = 10;
        }
    }
}
