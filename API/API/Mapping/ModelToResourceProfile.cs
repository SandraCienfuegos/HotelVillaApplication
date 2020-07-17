using API.Domain.Models;
using API.Resources;
using AutoMapper;

namespace API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Country, CountryResource>();

            CreateMap<Customer, AuthenticatedCustomerResource>();

            CreateMap<Customer, CustomerResource>();

            CreateMap<Equipment, EquipmentResource>();

            CreateMap<Extra, ExtraResource>();

            CreateMap<ExtraLanguage, ExtraLanguageResource>();

            CreateMap<Formula, FormulaResource>();

            CreateMap<Language, LanguageResource>();

            CreateMap<Reservation, ReservationResource>();

            CreateMap<ReservationExtra, ReservationExtraResource>();

            CreateMap<ReservationService, ReservationServiceResource>();

            CreateMap<Service, ServiceResource>();

            CreateMap<Villa, VillaResource>();

            CreateMap<VillaFormula, VillaFormulaResource>()
                .ForMember(
                    dest => dest.FormulaId,
                    opt => opt.MapFrom(src => src.Formula.FormulaId)
                ).ForMember(
                    dest => dest.FormulaName,
                    opt => opt.MapFrom(src => src.Formula.FormulaName)
                );

            CreateMap<VillaMedia, VillaMediaResource>();
        }
    }
}