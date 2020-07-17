using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain.Models;
using API.Domain.Repositories;
using API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence.Repositories
{
    public class AddressRepository : BaseRepository, IAddressRepository
    {
        public AddressRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Address address)
        {
            address.Country = null;
            await context.Addresses.AddAsync(address);
        }

        public void Update(Address address)
        {
            context.Addresses.Update(address);
        }
    }
}