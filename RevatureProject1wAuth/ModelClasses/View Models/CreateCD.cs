using ModelClasses.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClasses.View_Models
{
    public class CreateCD
    {
        public TermDepositTable termDepositTable = new TermDepositTable();

        public TermDeposit cd = new TermDeposit();
        public decimal DepositAmount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

    }
}
