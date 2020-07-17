using System.Collections.Generic;

namespace API.Domain.Models
{
    public class Country
    {
        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public IEnumerable<Address> Addresses { get; set; }
    }
}