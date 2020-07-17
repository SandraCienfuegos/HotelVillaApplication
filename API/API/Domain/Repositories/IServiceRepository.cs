using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Models;

namespace API.Domain.Repositories
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> ListAsync(string language);

        // Task AddAsync(Service service);

        Task<Service> FindByIdAsync(int id, string language);

        // void Update(Service service);

        // void Remove(Service service);
    }
}