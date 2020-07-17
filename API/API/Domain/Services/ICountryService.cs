using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Models;
using API.Domain.Services.Communication;

namespace API.Domain.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> ListAsync();
    }
}