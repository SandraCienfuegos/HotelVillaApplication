namespace API.Domain.Models
{
    public class ExtraLanguage
    {
        public int ExtraId { get; set; }

        public Extra Extra { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }

        public string ExtraName { get; set; }
    }
}