using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Models;

namespace API.Domain.Repositories
{
    public interface IVillaMediaRepository
    {
        Task<IEnumerable<VillaMedia>> ListAsync(string language);

        Task<IEnumerable<VillaMedia>> ListMediaByVillaIdAsync(int villaId, string language);

        // Task AddAsync(VillaMedia villa);

        Task<VillaMedia> FindByIdAsync(int id, string language);

        // void Update(VillaMedia villa);

        // void Remove(VillaMedia villa);
    }
}