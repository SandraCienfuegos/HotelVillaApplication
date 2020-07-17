namespace API.Domain.Models
{
    public class ServiceLanguage
    {
        public int ServiceId { get; set; }

        public Service Service { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }

        public string ServiceName { get; set; }
    }
}