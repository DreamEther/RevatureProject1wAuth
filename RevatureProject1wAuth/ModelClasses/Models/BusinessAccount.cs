using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClasses.Models
{
    public class BusinessAccount : Account
    {
        public BusinessAccount()
        {
            AccountType = "Business";
            Balance = 0;
            InterestRate = 10;
        }
    }
}
