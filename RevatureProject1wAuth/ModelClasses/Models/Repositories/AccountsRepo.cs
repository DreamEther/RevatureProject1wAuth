using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClasses.Models.Repositories
{
    public class AccountsRepo : IAccountRepo
    {
        private MyDbContext _context;

        public AccountsRepo(MyDbContext context)
        {
            _context = context;
        }

      
        public async Task<Account> GetAccount(int id)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.ID == id);
            
            return account;
        }
        public async Task<AccountTypes> GetAccountType(int id)
        {
            var account = await _context.AccountTypes.FirstOrDefaultAsync(x => x.ID == id);

            return account;
        }

        public async Task<bool> AddToLoanTable(LoanTable loanTable)
        {
            _context.Loans.Add(loanTable);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddToTermDepositTable(TermDepositTable termTable)
        {
            _context.TermDeposits.Add(termTable);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<AccountTypes>> GetAccountTypes()
        {
            var accounts = await _context.AccountTypes.ToListAsync();

            return accounts;
        }

        public async Task<List<Account>> Get()
        {
            var accounts = await _context.Accounts.ToListAsync();
            return accounts;
        }

        public async Task<bool> Create(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddTransaction(Transaction transaction)
        {
            _context.Update(transaction);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Transaction>> GetTransactions(int id)
        {
            var getTransactions = await _context.Transactions.Where(x => x.AccountID == id).ToListAsync();
            return getTransactions;
        }

        public async Task<bool> DeleteAccount(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
