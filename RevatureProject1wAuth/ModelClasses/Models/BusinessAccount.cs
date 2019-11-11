using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClasses.Models
{
    public class BusinessAccount : Account
    {
        public BusinessAccount()
        {
            AccountTypeAsString = "Business";
            Balance = 0;
            IsClosed = false;

            // AccountTypesID = 2;
        }
    }
}
