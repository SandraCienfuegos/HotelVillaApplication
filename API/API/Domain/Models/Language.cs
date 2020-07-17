using System.Collections.Generic;

namespace API.Domain.Models
{
    public class Language
    {
        public int LanguageId { get; set; }

        public string IsoCode { get; set; }

        public bool IsDefault { get; set; }

        public IEnumerable<EquipmentLanguage> EquipmentLanguages { get; set; }

        public IEnumerable<ExtraLanguage> ExtraLanguages { get; set; }

        public IEnumerable<FormulaLanguage> FormulaLanguages { get; set; }

        public IEnumerable<ServiceLanguage> ServiceLanguages { get; set; }

        public IEnumerable<VillaLanguage> VillaLanguages { get; set; }
    }
}