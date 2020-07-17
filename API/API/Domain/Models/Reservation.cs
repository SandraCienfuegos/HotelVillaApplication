using System;
using System.Collections.Generic;

namespace API.Domain.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int VillaId { get; set; }

        public Villa Villa { get; set; }

        public int FormulaId { get; set; }

        public Formula Formula { get; set; }

        public int NumberAdults { get; set; }

        public int NumberChildren { get; set; }

        public int NumberBabies { get; set; }

        public DateTime ReservationDate { get; set; }

        public double ReservationPrice { get; set; }

        public EPriceChoice PriceChoice { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public IEnumerable<ReservationExtra> Extras { get; set; }

        public IEnumerable<ReservationService> Services { get; set; }
    }
}