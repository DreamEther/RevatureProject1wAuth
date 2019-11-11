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
