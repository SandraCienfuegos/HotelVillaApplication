using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Models;
using API.Domain.Repositories;
using API.Domain.Services;

namespace API.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            this.serviceRepository = serviceRepository;
        }

        public Task<IEnumerable<Service>> ListAsync(string language)
        {
            return serviceRepository.ListAsync(language);
        }

        public Task<Service> FindById(int serviceId, string language)
        {
            return serviceRepository.FindByIdAsync(serviceId, language);
        }
    }
}