namespace API.Domain.Models
{
    public class EquipmentLanguage
    {
        public int EquipmentId { get; set; }

        public Equipment Equipment { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }

        public string EquipmentName { get; set; }
    }
}