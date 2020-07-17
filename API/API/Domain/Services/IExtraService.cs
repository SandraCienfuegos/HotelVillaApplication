using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Models;

namespace API.Domain.Services
{
    public interface IExtraService
    {
        Task<IEnumerable<Extra>> ListAsync(string language);

        Task<Extra> FindByIdAsync(int extraId, string language);

        Task<List<ExtraLanguage>> FindTranslationsByIdAsync(int id);
    }
}