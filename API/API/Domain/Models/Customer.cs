using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public int AddressId { get; set; }

        public Address Address { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime BirthdayDate { get; set; }

        public ESex Sex { get; set; }

        [NotMapped] public string Token { get; set; }

        public IEnumerable<Reservation> Reservations { get; set; }
    }
}