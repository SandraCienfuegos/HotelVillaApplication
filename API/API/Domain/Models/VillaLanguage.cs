namespace API.Domain.Models
{
    public class VillaLanguage
    {
        public int VillaId { get; set; }

        public Villa Villa { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }

        public string Description { get; set; }
    }
}