using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevatureProject1wAuth.BusinessLayer
{
    public class CheckingAccountBL : AccountBusinessLayer
    { 
        public override decimal Withdraw(decimal balance, decimal withdrawalAmount)
        {
            var newBalance = (balance -= withdrawalAmount);
            return newBalance;
        }
    }
}
