using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelClasses.Models
{
    public class Customer 
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Pin is required")]
        public int Pin { get; set; }

        public string UserID { get; set; }

        public List<CheckingAccount> Accounts { get; set; }
     
       

    }
}
