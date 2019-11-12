using ModelClasses.Models;
using ModelClasses.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevatureProject1wAuth.BusinessLayer
{
    public class BusinessAccountBL : AccountBusinessLayer
    {

        public override decimal Withdraw(decimal balance, decimal withdrawalAmount, decimal interest)
        {
            var newBalance = (balance -= withdrawalAmount);
            if (newBalance < 0)
            {
                var overdraftBalance = (withdrawalAmount * interest) / 100;
                var newTotal = balance - overdraftBalance;
                return newTotal;
            }
            else
            {
                return newBalance;
            }
        }
    }
}
