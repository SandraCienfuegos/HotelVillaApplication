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
    public class VillaMediaRepository : BaseRepository, IVillaMediaRepository
    {
        public VillaMediaRepository(AppDbContext context) : base(context)
        {
        }

        public Task<IEnumerable<VillaMedia>> ListAsync(string language)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<VillaMedia>> ListMediaByVillaIdAsync(int villaId, string language)
        {
            return await context
                .VillaMedias
                .Where(x => x.VillaId == villaId)
                .Select(x => new VillaMedia
                {
                    MediaId = x.MediaId,
                    VillaId = x.VillaId,
                    MediaName = x.MediaName,
                })
                .ToListAsync();
        }

        public Task<VillaMedia> FindByIdAsync(int id, string language)
        {
            throw new NotImplementedException();
        }
    }
}