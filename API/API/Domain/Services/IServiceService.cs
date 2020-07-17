using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Models;

namespace API.Domain.Services
{
    public interface IServiceService
    {
        Task<IEnumerable<Service>> ListAsync(string language);

        Task<Service> FindById(int serviceId, string language);
    }
}