using System;

namespace Winforms
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

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}