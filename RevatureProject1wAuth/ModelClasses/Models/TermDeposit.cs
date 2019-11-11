using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelClasses.Models
{
    public class TermDeposit : Account
    {
        public TermDeposit()
        {
            AccountTypeAsString = "Term Deposit";
            Balance = 0;
            IsClosed = false;

            // AccountTypesID = 4;
        }
    }
}
