using System.Threading.Tasks;
using API.Controllers.Response;
using API.Domain.Models;
using API.Domain.Services;
using API.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("customers")]
    public class CustomersController : Controller
    {
        private readonly ICustomerService customerService;
        private readonly IMapper mapper;

        public CustomersController(ICustomerService customerService, IMapper mapper)
        {
            this.customerService = customerService;
            this.mapper = mapper;
        }

        [HttpPost("sign_up")]
        public async Task<IActionResult> SignUp([FromBody] SignUpCustomerResource signUpCustomerResource)
        {
            var customer = mapper.Map<SignUpCustomerResource, Customer>(signUpCustomerResource);

            var customerResponse = await customerService.SaveAsync(customer);

            if (!customerResponse.Success)
                return BadRequest(
                    new VillaHotelApiResponse<bool>(400, customerResponse.Message)
                );

            return Ok(
                new VillaHotelApiResponse<bool>(true));
        }

        [HttpPost("sign_in")]
        public async Task<IActionResult> SignIn([FromBody] CredentialsResource credentialsResource)
        {
            var customerResponse = await customerService.Authenticate(
                credentialsResource.Email, credentialsResource.Password
            );

            if (!customerResponse.Success)
                return BadRequest(
                    new VillaHotelApiResponse<AuthenticatedCustomerResource>(400, customerResponse.Message));

            return Ok(new VillaHotelApiResponse<AuthenticatedCustomerResource>(
                mapper.Map<Customer, AuthenticatedCustomerResource>(customerResponse.Resource))
            );
        }
    }
}