using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Models;
using API.Domain.Repositories;
using API.Infrastructure;
using API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence.Repositories
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Customer>> ListAsync()
        {
            return await context.Customers
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Customer> FindByIdAsync(int id)
        {
            return await context.Customers.FindAsync(id);
        }

        public async Task AddAsync(Customer customer)
        {
            await context.Customers.AddAsync(customer);
            context.Entry(customer).Reference(x => x.Address).Load();
        }

        public void Update(Customer customer)
        {
            context.Customers.Update(customer);
        }

        public void Remove(Customer customer)
        {
            context.Customers.Remove(customer);
        }

        public Task<Customer> Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            return context.Customers.SingleOrDefaultAsync(x =>
                x.Email == email &&
                x.Password == CryptographyTool.CryptSHA512(password)
            );
        }
    }
}