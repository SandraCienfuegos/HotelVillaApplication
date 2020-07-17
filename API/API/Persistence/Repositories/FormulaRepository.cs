using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain.Models;
using API.Domain.Repositories;
using API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence.Repositories
{
    public class FormulaRepository : BaseRepository, IFormulaRepository
    {
        public FormulaRepository(AppDbContext context) : base(context)
        {
        }

        public Task<IEnumerable<Formula>> ListAsync(string language)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<VillaFormula>> ListFormulaByVillaIdAsync(int villaId, string language)
        {
            return await context.VillaFormulas
                .Include(x => x.Formula)
                .ThenInclude(x => x.FormulaLanguages)
                .Where(x => x.VillaId == villaId)
                .Select(x => new VillaFormula
                {
                    VillaId = x.VillaId,
                    FormulaId = x.FormulaId,
                    Formula = new Formula
                    {
                        FormulaId = x.Formula.FormulaId,
                        FormulaName = x
                            .Formula
                            .FormulaLanguages.Single(l => l.Language.IsoCode == language.ToUpper())
                            .FormulaName,
                    },
                    PriceAdult = x.PriceAdult,
                    PriceChild = x.PriceChild,
                    PriceBaby = x.PriceBaby,
                })
                .ToListAsync();
        }

        public Task<Formula> FindByIdAsync(int id, string language)
        {
            throw new NotImplementedException();
        }
    }
}