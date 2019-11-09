using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClasses.Models
{
    public class TermDeposit : Account
    {
        public TermDeposit()
        {
            AccountTypeAsString = "Term Deposit";
            Balance = 0;
            InterestRate = 6;
            IsClosed = false;
           // AccountTypesID = 4;
        }
    }
}
