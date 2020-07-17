using API.Domain.Models;

namespace API.Domain.Services.Communication
{
    public class ReservationResponse : BaseResponse<Reservation>
    {
        public ReservationResponse(Reservation customer) : base(customer)
        {
        }

        public ReservationResponse(string message) : base(message)
        {
        }
    }
}