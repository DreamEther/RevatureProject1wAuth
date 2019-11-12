using ModelClasses.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClasses.View_Models
{
    public class SearchTransactions
    {
        public List<Transaction> Transactions = new List<Transaction>();

        public Transaction Transaction { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
