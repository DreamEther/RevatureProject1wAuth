using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClasses.Models
{
    public class LoanTable
    {
        public int ID { get; set; }
        public int AccountID { get; set; }

        public int MonthlyPlan { get; set; }

        public decimal AmountDuePerMonth { get; set; }

    }
}
