namespace API.Domain.Models
{
    public class VillaFormula
    {
        public int VillaId { get; set; }

        public Villa Villa { get; set; }

        public int FormulaId { get; set; }

        public Formula Formula { get; set; }

        public double PriceAdult { get; set; }

        public double PriceChild { get; set; }

        public double PriceBaby { get; set; }
    }
}