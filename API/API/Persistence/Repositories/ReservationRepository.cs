using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain.Models;
using API.Domain.Repositories;
using API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence.Repositories
{
    public class ReservationRepository : BaseRepository, IReservationRepository
    {
        public ReservationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Reservation reservation)
        {
            await context.Reservations.AddAsync(reservation);
            await context.ReservationExtras.AddRangeAsync(reservation.Extras);
            await context.ReservationServices.AddRangeAsync(reservation.Services);
            await context.Entry(reservation).Reference(x => x.Customer).LoadAsync();
            await context.Entry(reservation).Reference(x => x.Villa).LoadAsync();
        }
    }
}