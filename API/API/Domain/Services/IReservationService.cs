using System.Threading.Tasks;
using API.Domain.Models;
using API.Domain.Services.Communication;

namespace API.Domain.Services
{
    public interface IReservationService
    {
        Task<ReservationResponse> SaveAsync(Reservation reservation);
    }
}