using ModelClasses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevatureProject1wAuth.BusinessLayer
{
    public class BusinessAccountBL : AccountBusinessLayer
    {
        BusinessAccount bus = new BusinessAccount();
        public override decimal Withdraw(decimal balance, decimal withdrawalAmount)
        {
            var newBalance = (balance -= withdrawalAmount);
            if (newBalance < 0)
            {
                var overdraftBalance = (newBalance * bus.InterestRate) / 100;
                return overdraftBalance;
            }
            else
            {
                return newBalance;
            }
        }
    }
}
