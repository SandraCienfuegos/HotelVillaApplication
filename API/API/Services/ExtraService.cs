using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Models;
using API.Domain.Repositories;
using API.Domain.Services;

namespace API.Services
{
    public class ExtraService : IExtraService
    {
        private readonly IExtraRepository extraRepository;

        public ExtraService(IExtraRepository extraRepository)
        {
            this.extraRepository = extraRepository;
        }

        public Task<IEnumerable<Extra>> ListAsync(string language)
        {
            return extraRepository.ListAsync(language);
        }

        public Task<Extra> FindByIdAsync(int extraId, string language)
        {
            return extraRepository.FindByIdAsync(extraId, language);
        }

        public Task<List<ExtraLanguage>> FindTranslationsByIdAsync(int id)
        {
            return extraRepository.FindTranslationsByIdAsync(id);
        }
    }
}