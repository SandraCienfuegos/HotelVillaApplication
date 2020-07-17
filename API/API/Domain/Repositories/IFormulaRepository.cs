using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Models;

namespace API.Domain.Repositories
{
    public interface IFormulaRepository
    {
        Task<IEnumerable<Formula>> ListAsync(string language);

        Task<IEnumerable<VillaFormula>> ListFormulaByVillaIdAsync(int villaId, string language);

        // Task AddAsync(Formula equipment);

        Task<Formula> FindByIdAsync(int id, string language);

        // void Update(Formula equipment);

        // void Remove(Formula equipment);
    }
}