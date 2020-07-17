namespace API.Domain.Models
{
    public class VillaEquipment
    {
        public int VillaId { get; set; }

        public Villa Villa { get; set; }

        public int EquipmentId { get; set; }

        public Equipment Equipment { get; set; }
    }
}