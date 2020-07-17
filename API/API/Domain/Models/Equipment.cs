using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Models
{
    public class Equipment
    {
        public int EquipmentId { get; set; }

        public string IconFile { get; set; }

        [NotMapped] public string EquipmentName { get; set; }

        public IEnumerable<EquipmentLanguage> EquipmentLanguages { get; set; }

        public IEnumerable<VillaEquipment> VillaEquipments { get; set; }
    }
}