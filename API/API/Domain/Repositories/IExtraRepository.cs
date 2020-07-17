using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Models;

namespace API.Domain.Repositories
{
    public interface IExtraRepository
    {
        Task<IEnumerable<Extra>> ListAsync(string language);

        // Task AddAsync(Extra extra);

        Task<Extra> FindByIdAsync(int id, string language);

        // void Update(Extra extra);

        // void Remove(Extra extra);

        Task<List<ExtraLanguage>> FindTranslationsByIdAsync(int id);
    }
}