using System.ComponentModel;

namespace API.Domain.Models
{
    public enum ESex : byte
    {
        [Description("M")] Male = 1,

        [Description("F")] Female = 2,
    }
}