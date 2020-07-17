using System.Threading.Tasks;
using API.Domain.Models;

namespace API.Domain.Repositories
{
    public interface IAddressRepository
    {
        Task AddAsync(Address address);

        void Update(Address address);
    }
}