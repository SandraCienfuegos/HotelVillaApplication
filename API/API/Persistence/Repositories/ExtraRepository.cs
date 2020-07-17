using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain.Models;
using API.Domain.Repositories;
using API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence.Repositories
{
    public class ExtraRepository : BaseRepository, IExtraRepository
    {
        public ExtraRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Extra>> ListAsync(string language)
        {
            return await context.Extras
                .Include(x => x.ExtraLanguages)
                .Select(x => new Extra
                {
                    ExtraId = x.ExtraId,
                    ExtraPrice = x.ExtraPrice,
                    ExtraName = x
                        .ExtraLanguages.Single(l => l.Language.IsoCode == language.ToUpper())
                        .ExtraName,
                })
                .ToListAsync();
        }

        public async Task<Extra> FindByIdAsync(int id, string language)
        {
            return await context.Extras
                .Include(x => x.ExtraLanguages)
                .Select(x => new Extra
                {
                    ExtraId = x.ExtraId,
                    ExtraPrice = x.ExtraPrice,
                    ExtraName = x
                        .ExtraLanguages.Single(l => l.Language.IsoCode == language.ToUpper())
                        .ExtraName,
                })
                .SingleOrDefaultAsync(x => x.ExtraId == id);
        }

        public async Task<List<ExtraLanguage>> FindTranslationsByIdAsync(int id)
        {
            return await context.ExtraLanguages
                .Include(x => x.Language)
                .Where(x => x.ExtraId == id)
                .ToListAsync();
        }
    }
}