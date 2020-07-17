using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Models
{
    public class Villa
    {
        public int VillaId { get; set; }

        public string VillaName { get; set; }

        public string VillaPath { get; set; }

        public int NumberOfBeds { get; set; }

        public double SurfaceArea { get; set; }

        public double PriceOnline { get; set; }

        public double PriceOnSite { get; set; }

        [NotMapped] public string Description { get; set; }

        public IEnumerable<Reservation> Reservations { get; set; }

        public IEnumerable<VillaEquipment> Equipments { get; set; }

        public IEnumerable<VillaFormula> Formulas { get; set; }

        public IEnumerable<VillaLanguage> Languages { get; set; }

        public IEnumerable<VillaMedia> Medias { get; set; }
    }
}