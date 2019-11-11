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
                var overdraftBalance = (newBalance * interest) / 100;
                return overdraftBalance;
            }
            else
            {
                return newBalance;
            }
        }
    }
}
