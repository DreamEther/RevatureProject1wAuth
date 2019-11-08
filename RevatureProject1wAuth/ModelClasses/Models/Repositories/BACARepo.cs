using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClasses.Models.Repositories
{
    public class BACARepo
    {
        private MyDbContext _context;

        public BACARepo(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Account> GetAccount(int id)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.ID == id);
            
            return account;
        }

        public async Task<List<Account>> Get()
        {
            var accounts = await _context.Accounts.ToListAsync();
            return accounts;
        }

        public async Task<bool> Create(Account account)
        {
            _context.Add(account);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddTransaction(Transaction transaction)
        {
            _context.Update(transaction);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Transaction>> GetTransactions(Transaction transaction)
        {
            var getTransactions = await _context.Transactions.Where(x => x.AccountID == transaction.AccountID).ToListAsync();
            return getTransactions;
        }
    }
}
