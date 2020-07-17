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
    public class VillaRepository : BaseRepository, IVillaRepository
    {
        public VillaRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Villa>> ListAsync(string language)
        {
            return await context
                .Villas
                .Include(x => x.Languages)
                .ThenInclude(x => x.Language)
                .Include(x => x.Medias)
                .Select(x => new Villa
                {
                    VillaId = x.VillaId,
                    VillaName = x.VillaName,
                    VillaPath = x.VillaPath,
                    NumberOfBeds = x.NumberOfBeds,
                    SurfaceArea = x.SurfaceArea,
                    PriceOnline = x.PriceOnline,
                    PriceOnSite = x.PriceOnSite,
                    Description = x.Languages.Single(l => l.Language.IsoCode == language.ToUpper()).Description,
                    Medias = x.Medias.ToList(),
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> ListReservations(int id)
        {
            return await context
                .Reservations
                .Where(x => x.VillaId == id &&
                            (x.CheckInDate.CompareTo(DateTime.Now) >= 0 ||
                             x.CheckOutDate.CompareTo(DateTime.Now) >= 0))
                .ToListAsync();
        }

        public async Task<Villa> FindByIdAsync(int id, string language)
        {
            return await context
                .Villas
                .Include(x => x.Languages)
                .ThenInclude(x => x.Language)
                .Include(x => x.Medias)
                .Select(x => new Villa
                {
                    VillaId = x.VillaId,
                    VillaName = x.VillaName,
                    VillaPath = x.VillaPath,
                    NumberOfBeds = x.NumberOfBeds,
                    SurfaceArea = x.SurfaceArea,
                    PriceOnline = x.PriceOnline,
                    PriceOnSite = x.PriceOnSite,
                    Description = x.Languages.Single(l => l.Language.IsoCode == language.ToUpper()).Description,
                    Medias = x.Medias.ToList(),
                })
                .SingleOrDefaultAsync(x => x.VillaId == id);
        }
    }
}