namespace API.Domain.Models
{
    public class FormulaLanguage
    {
        public int FormulaId { get; set; }

        public Formula Formula { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }

        public string FormulaName { get; set; }
    }
}