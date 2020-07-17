using System.ComponentModel;

namespace API.Domain.Models
{
    public enum EPriceChoice : byte
    {
        [Description("PO")] PriceOnline = 1,

        [Description("POS")] PriceOnSite = 2,
    }
}