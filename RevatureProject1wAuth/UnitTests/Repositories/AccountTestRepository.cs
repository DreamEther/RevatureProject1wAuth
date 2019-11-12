using ModelClasses.Models;
using ModelClasses.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Repositories
{
    public class AccountTestRepository : IAccountRepo
    {
        private static List<Account> _accounts = new List<Account>()

        {

            new CheckingAccount()

            {

                ID = 101,
                AccountTypeAsString = "Checking",
                InterestRate = 5,
                Balance = 100
            }
    
    

           

        };
        public Task<bool> AddToLoanTable(LoanTable loanTable)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<List<Account>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetAccount(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AccountTypes> GetAccountType(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AccountTypes>> GetAccountTypes()
        {
            throw new NotImplementedException();
        }

        public Task<List<Transaction>> GetTransactions(int id)
        {
            throw new NotImplementedException();
        }
    }
}
