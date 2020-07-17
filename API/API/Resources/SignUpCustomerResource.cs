using System;
using API.Domain.Models;

namespace API.Resources
{
    public class SignUpCustomerResource
    {
        public AddressResource Address { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime BirthdayDate { get; set; }

        public ESex Sex { get; set; }
    }
}