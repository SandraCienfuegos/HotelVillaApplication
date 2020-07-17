using API.Domain.Models;

namespace API.Domain.Services.Communication
{
    public class CustomerResponse : BaseResponse<Customer>
    {
        public CustomerResponse(Customer customer) : base(customer)
        {
        }

        public CustomerResponse(string message) : base(message)
        {
        }
    }
}