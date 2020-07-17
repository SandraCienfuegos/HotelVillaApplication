using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Models;
using API.Domain.Repositories;
using API.Domain.Services;

namespace API.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository countryRepository;
        private readonly IUnitOfWork unitOfWork;

        public CountryService(
            ICountryRepository customerRepository,
            IUnitOfWork unitOfWork)
        {
            this.countryRepository = customerRepository;
            this.unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<Country>> ListAsync()
        {
            return countryRepository.ListAsync();
        }
    }
}