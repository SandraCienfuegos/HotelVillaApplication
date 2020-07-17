using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Models;

namespace API.Domain.Services
{
    public interface IVillaService
    {
        Task<IEnumerable<Villa>> ListAsync(string language);

        Task<Villa> FindById(int villaId, string language);

        Task<IEnumerable<Equipment>> ListEquipmentsAsync(int villaId, string language);

        Task<IEnumerable<VillaFormula>> ListFormulasAsync(int villaId, string language);

        Task<IEnumerable<VillaMedia>> ListMediasAsync(int villaId, string language);

        Task<IEnumerable<DateTime>> ListBookedDates(int id);
    }
}