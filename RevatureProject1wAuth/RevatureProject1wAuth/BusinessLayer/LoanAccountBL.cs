using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevatureProject1wAuth.BusinessLayer
{
    public class LoanAccountBL
    {
        public decimal Balance { get; set; }

        public decimal MakePayment(decimal balance, decimal amount)
        {
            Balance = (balance -= amount);
            return Balance;
        }
    }
}
