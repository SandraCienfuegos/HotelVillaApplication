namespace API.Domain.Models
{
    public class ReservationExtra
    {
        public int ReservationId { get; set; }

        public Reservation Reservation { get; set; }

        public int ExtraId { get; set; }

        public Extra Extra { get; set; }

        public int Number { get; set; }
    }
}