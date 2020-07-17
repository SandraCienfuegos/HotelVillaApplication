using System;
using API.Domain.Models;

namespace API.Resources
{
    public class CustomerResource
    {
        public int CustomerId { get; set; }

        public int AddressId { get; set; }

        public AddressResource Address { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public DateTime BirthdayDate { get; set; }
    }
}