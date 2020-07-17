using API.Domain.Models;
using API.Resources;
using AutoMapper;

namespace API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<AddressResource, Address>();

            CreateMap<CountryResource, Country>();

            CreateMap<NewReservationResource, Reservation>();

            CreateMap<ReservationExtraResource, ReservationExtra>();

            CreateMap<ReservationServiceResource, ReservationService>();

            CreateMap<SignUpCustomerResource, Customer>();
        }
    }
}