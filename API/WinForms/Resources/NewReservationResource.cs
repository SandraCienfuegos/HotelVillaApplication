using System;
using System.Collections.Generic;

namespace Winforms
{
    public class NewReservationResource
    {
        public int VillaId { get; set; }

        public int FormulaId { get; set; }

        public int NumberAdults { get; set; }

        public int NumberChildren { get; set; }

        public int NumberBabies { get; set; }

        public DateTime ReservationDate { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public IEnumerable<ReservationExtraResource> Extras { get; set; }

        public IEnumerable<ReservationServiceResource> Services { get; set; }
    }
}