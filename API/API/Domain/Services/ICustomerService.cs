using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Models;
using API.Domain.Services.Communication;

namespace API.Domain.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> ListAsync();

        Task<CustomerResponse> FindByIdAsync(int id);

        Task<CustomerResponse> SaveAsync(Customer customer);

        Task<CustomerResponse> UpdateAsync(int id, Customer customer);

        // Task<CustomerResponse> DeleteAsync(int id);

        Task<CustomerResponse> Authenticate(string email, string password);
    }
}