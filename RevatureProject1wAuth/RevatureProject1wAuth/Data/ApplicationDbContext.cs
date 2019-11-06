using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModelClasses.Models;

namespace RevatureProject1wAuth.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"data source=.\SQLEXPRESS;initial catalog=MyDb;integrated security=True;MultipleActiveResultSets=True;");
            }
        }

    }
}
