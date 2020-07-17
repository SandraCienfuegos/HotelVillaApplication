using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Models;

namespace API.Domain.Repositories
{
    public interface IReservationRepository
    {
        Task AddAsync(Reservation reservation);
    }
}