using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Models;
using API.Domain.Services;
using API.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [CultureRoute("services")]
    public class ServicesController : CultureController
    {
        private readonly IServiceService serviceService;
        private readonly IMapper mapper;

        public ServicesController(IServiceService serviceService, IMapper mapper)
        {
            this.serviceService = serviceService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ServiceResource>> ServicesList()
        {
            var services = await serviceService.ListAsync(Language);

            return mapper.Map<IEnumerable<Service>, IEnumerable<ServiceResource>>(services);
        }

        [HttpGet("{id}")]
        public async Task<ServiceResource> Service(int id)
        {
            var service = await serviceService.FindById(id, Language);

            return mapper.Map<Service, ServiceResource>(service);
        }
    }
}