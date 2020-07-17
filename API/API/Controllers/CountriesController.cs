using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Models;
using API.Domain.Services;
using API.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("countries")]
    public class CountriesController : Controller
    {
        private readonly ICountryService countryService;
        private readonly IMapper mapper;

        public CountriesController(ICountryService countryService, IMapper mapper)
        {
            this.countryService = countryService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CountryResource>> CountriesList()
        {
            var services = await countryService.ListAsync();

            return mapper.Map<IEnumerable<Country>, IEnumerable<CountryResource>>(services);
        }
    }
}