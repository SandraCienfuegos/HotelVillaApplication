using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Models;

namespace API.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> ListAsync();

        Task<Customer> FindByIdAsync(int id);

        Task AddAsync(Customer customer);

        void Update(Customer customer);

        void Remove(Customer customer);

        Task<Customer> Authenticate(string email, string password);
    }
}