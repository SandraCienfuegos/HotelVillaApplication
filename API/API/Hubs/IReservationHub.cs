using System.Threading.Tasks;
using API.Domain.Models;
using API.Resources;

namespace API.Hubs
{
    public interface IReservationHub
    {
        Task BroadCastReservation(ReservationResource reservation);
    }
}