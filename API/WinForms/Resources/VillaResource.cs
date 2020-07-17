using System.Collections.Generic;

namespace Winforms
{
    public class VillaResource
    {
        public int VillaId { get; set; }

        public string VillaName { get; set; }

        public string VillaPath { get; set; }

        public int NumberOfBeds { get; set; }

        public double SurfaceArea { get; set; }

        public double PriceOnline { get; set; }

        public double PriceOnSite { get; set; }

        public string Description { get; set; }

        public IEnumerable<VillaMediaResource> Medias { get; set; }

        public override string ToString()
        {
            return VillaName;
        }
    }
}