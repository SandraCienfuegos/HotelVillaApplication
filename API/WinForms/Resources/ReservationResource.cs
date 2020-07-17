using System;
using System.Collections.Generic;

namespace Winforms
{
    public class ReservationResource
    {
        public CustomerResource Customer { get; set; }

        public VillaResource Villa { get; set; }

        public FormulaResource Formula { get; set; }

        public int NumberAdults { get; set; }

        public int NumberChildren { get; set; }

        public int NumberBabies { get; set; }

        public DateTime ReservationDate { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }
    }
}