﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClasses.Models
{
    public class MyDbContext: DbContext
    {

        public MyDbContext(DbContextOptions<MyDbContext> options)
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
    public DbSet<Customer> Customers { get; set; }
    }
}