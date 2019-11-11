using ModelClasses.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClasses.View_Models
{
    public class TakeOutALoan
    {
        public LoanTable loanTable = new LoanTable();
        public Loan loan = new Loan();
        public decimal LoanAmount { get; set; }

        public int MonthlyPlan { get; set; }
    }
}
