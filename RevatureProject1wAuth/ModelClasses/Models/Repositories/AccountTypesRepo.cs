using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace ModelClasses.Models.Repositories
{
    public class AccountTypesRepo
    {
        private MyDbContext _context;

        public AccountTypesRepo(MyDbContext context)
        {
            _context = context;
        }
        public async Task<AccountTypes> GetById(int id)
        {
            var account = await _context.AccountTypes.FirstOrDefaultAsync(x => x.ID == id);

            return account;
        }

    }
}
