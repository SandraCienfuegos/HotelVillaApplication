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
    public class EquipmentRepository : BaseRepository, IEquipmentRepository
    {
        public EquipmentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Equipment>> ListAsync(string language)
        {
            return await context.VillaEquipments
                .Include(x => x.Equipment)
                .ThenInclude(x => x.EquipmentLanguages)
                .Select(x => new Equipment
                {
                    EquipmentId = x.EquipmentId,
                    IconFile = x.Equipment.IconFile,
                    EquipmentName = x
                        .Equipment
                        .EquipmentLanguages.Single(l => l.Language.IsoCode == language.ToUpper())
                        .EquipmentName,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<Equipment>> ListEquipmentByVillaIdAsync(int villaId, string language)
        {
            return await context.VillaEquipments
                .Include(x => x.Equipment)
                .ThenInclude(x => x.EquipmentLanguages)
                .Where(x => x.VillaId == villaId)
                .Select(x => new Equipment
                {
                    EquipmentId = x.EquipmentId,
                    IconFile = x.Equipment.IconFile,
                    EquipmentName = x
                        .Equipment
                        .EquipmentLanguages.Single(l => l.Language.IsoCode == language.ToUpper())
                        .EquipmentName,
                })
                .ToListAsync();
        }

        public async Task<Equipment> FindByIdAsync(int id, string language)
        {
            return await context.VillaEquipments
                .Include(x => x.Equipment)
                .ThenInclude(x => x.EquipmentLanguages)
                .Select(x => new Equipment
                {
                    EquipmentId = x.EquipmentId,
                    IconFile = x.Equipment.IconFile,
                    EquipmentName = x
                        .Equipment
                        .EquipmentLanguages.Single(l => l.Language.IsoCode == language.ToUpper())
                        .EquipmentName,
                })
                .SingleOrDefaultAsync(x => x.EquipmentId == id);
        }
    }
}