using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Models;

namespace API.Domain.Repositories
{
    public interface IEquipmentRepository
    {
        Task<IEnumerable<Equipment>> ListAsync(string language);

        Task<IEnumerable<Equipment>> ListEquipmentByVillaIdAsync(int villaId, string language);

        // Task AddAsync(Equipment equipment);

        Task<Equipment> FindByIdAsync(int id, string language);

        // void Update(Equipment equipment);

        // void Remove(Equipment equipment);
    }
}