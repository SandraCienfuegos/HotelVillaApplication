namespace API.Domain.Models
{
    public class ReservationService
    {
        public int ReservationId { get; set; }

        public Reservation Reservation { get; set; }

        public int ServiceId { get; set; }

        public Service Service { get; set; }
    }
}