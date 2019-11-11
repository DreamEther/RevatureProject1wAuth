using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevatureProject1wAuth.BusinessLayer
{
    public abstract class AccountBusinessLayer
    {
        public decimal Balance { get; set; }

        public virtual decimal Deposit(decimal balance, decimal amount)
        {
            Balance = (balance += amount);
            return Balance;
        }

        public virtual string DepositAsString(decimal amount)
        {
            string depositString = amount.ToString();
            string appendSymbol = "+$" + depositString;
            return appendSymbol;
        }

        public virtual string WithdrawalAsString(decimal amount)
        {
            string withdrawalString = amount.ToString();
            string appendSymbol = "-$" + withdrawalString;
            return appendSymbol;
        }
        public abstract decimal Withdraw(decimal balance, decimal withdrawalAmount, decimal interest);
    }
}
