using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Models
{
    public class Extra
    {
        public int ExtraId { get; set; }

        public double ExtraPrice { get; set; }

        [NotMapped] public string ExtraName { get; set; }

        public IEnumerable<ReservationExtra> ReservationExtras { get; set; }

        public IEnumerable<ExtraLanguage> ExtraLanguages { get; set; }
    }
}