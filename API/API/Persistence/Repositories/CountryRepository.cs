using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Models;
using API.Domain.Repositories;
using API.Infrastructure;
using API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence.Repositories
{
    public class CountryRepository : BaseRepository, ICountryRepository
    {
        public CountryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Country>> ListAsync()
        {
            return await context.Countries
                .AsNoTracking()
                .ToListAsync();
        }
    }
}