using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Models
{
    public class Formula
    {
        public int FormulaId { get; set; }

        [NotMapped] public string FormulaName { get; set; }

        public IEnumerable<FormulaLanguage> FormulaLanguages { get; set; }

        public IEnumerable<Reservation> FormulaReservations { get; set; }

        public IEnumerable<VillaFormula> VillaFormulas { get; set; }
    }
}