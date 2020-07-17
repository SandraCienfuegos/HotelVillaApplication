using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain.Models;
using API.Domain.Repositories;
using API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence.Repositories
{
    public class ServiceRepository : BaseRepository, IServiceRepository
    {
        public ServiceRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Service>> ListAsync(string language)
        {
            return await context.Services
                .Include(x => x.ServiceLanguages)
                .Select(x => new Service
                {
                    ServiceId = x.ServiceId,
                    ServicePrice = x.ServicePrice,
                    ServiceName = x
                        .ServiceLanguages.Single(l => l.Language.IsoCode == language.ToUpper())
                        .ServiceName,
                })
                .ToListAsync();
        }

        public async Task<Service> FindByIdAsync(int id, string language)
        {
            return await context.Services
                .Include(x => x.ServiceLanguages)
                .Select(x => new Service
                {
                    ServiceId = x.ServiceId,
                    ServicePrice = x.ServicePrice,
                    ServiceName = x
                        .ServiceLanguages.Single(l => l.Language.IsoCode == language.ToUpper())
                        .ServiceName,
                })
                .SingleOrDefaultAsync(x => x.ServiceId == id);
        }
    }
}