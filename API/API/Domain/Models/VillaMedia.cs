namespace API.Domain.Models
{
    public class VillaMedia
    {
        public int MediaId { get; set; }

        public int VillaId { get; set; }

        public Villa Villa { get; set; }

        public string MediaName { get; set; }
    }
}