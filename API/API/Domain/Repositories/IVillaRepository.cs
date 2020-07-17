using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Models;

namespace API.Domain.Repositories
{
    public interface IVillaRepository
    {
        Task<IEnumerable<Villa>> ListAsync(string language);

        // Task AddAsync(Villa villa);

        Task<IEnumerable<Reservation>> ListReservations(int id);

        Task<Villa> FindByIdAsync(int id, string language);

        // void Update(Villa villa);

        // void Remove(Villa villa);
    }
}