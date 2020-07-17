using System;
using Microsoft.EntityFrameworkCore.Storage;

namespace API.Domain.Models
{
    public class Address
    {
        public int AddressId { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public string LineOne { get; set; }

        public string LineTwo { get; set; }

        public string PostCode { get; set; }

        public string City { get; set; }

        public Customer Customer { get; set; }
    }
}