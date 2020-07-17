namespace API.Resources
{
    public class AddressResource
    {
        public CountryResource Country { get; set; }

        public int CountryId { get; set; }

        public string LineOne { get; set; }

        public string LineTwo { get; set; }

        public string PostCode { get; set; }

        public string City { get; set; }
    }
}