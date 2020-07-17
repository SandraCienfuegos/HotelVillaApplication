namespace API.Resources
{
    public class ExtraLanguageResource
    {
        public int ExtraId { get; set; }

        public int LanguageId { get; set; }

        public LanguageResource Language { get; set; }

        public string ExtraName { get; set; }
    }
}