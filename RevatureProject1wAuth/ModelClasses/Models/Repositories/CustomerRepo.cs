using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ModelClasses.Models.Repositories
{
    public class CustomerRepo
    {
        private MyDbContext _context;

        public CustomerRepo(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> Get(int? id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(m => m.ID == id);
            return customer; // returning the customer object
        }

        public async Task<List<Customer>> Get()
        {
            var customer = await _context.Customers.ToListAsync();
            return customer;
        }

        public async Task<bool> Create(Customer customer)
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();
            return true;
        }

       
    }
}
    

