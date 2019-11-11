using Microsoft.EntityFrameworkCore;
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
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"data source=.\SQLEXPRESS;initial catalog=MyDb;integrated security=True;MultipleActiveResultSets=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Example of controlling TPH iheritance:
            modelBuilder.Entity<Account>().HasDiscriminator<int>("AccountTypesID").HasValue<CheckingAccount>(1)
        .HasValue<BusinessAccount>(2).HasValue<Loan>(3).HasValue<TermDeposit>(4);
            //  .Map<CheckingAccount>(m => m.Requires("MyType").HasValue("G"))
            //  .Map<ClubPaymentComponent>(m => m.Requires("MyType").HasValue("C"));

            // Example of controlling Foreign key:
            //modelBuilder.Entity<AccountType>()
            //            .HasMany(p => p.)
            //            .WithRequired()
            //            .Map(m => m.MapKey("PaymentId"));
        }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<AccountTypes> AccountTypes { get; set; }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    public DbSet<TermDepositTable> TermDeposits{ get; set; }

  
    public DbSet<LoanTable> Loans { get; set; }

    }
}
