using ModelClasses.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClasses.View_Models
{
    public class CreateAccount
    {
        public List<Account> accounts = new List<Account>();

        public AccountTypes AccountTypes { get; set; }
    }
}
