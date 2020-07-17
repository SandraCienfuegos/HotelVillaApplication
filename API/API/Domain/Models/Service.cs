using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Models
{
    public class Service
    {
        public int ServiceId { get; set; }

        public double ServicePrice { get; set; }

        [NotMapped] public string ServiceName { get; set; }

        public IEnumerable<ServiceLanguage> ServiceLanguages { get; set; }

        public IEnumerable<ReservationService> ReservationServices { get; set; }
    }
}