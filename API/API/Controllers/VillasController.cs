using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Models;
using API.Domain.Services;
using API.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [CultureRoute("villas")]
    public class VillasController : CultureController
    {
        private readonly IVillaService villaService;
        private readonly IMapper mapper;

        public VillasController(IVillaService villaService, IMapper mapper)
        {
            this.villaService = villaService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<VillaResource>> VillasList()
        {
            var villas = await villaService.ListAsync(Language);

            return mapper.Map<IEnumerable<Villa>, IEnumerable<VillaResource>>(villas);
        }

        [HttpGet("{id}")]
        public async Task<VillaResource> Villa(int id)
        {
            var villa = await villaService.FindById(id, Language);

            return mapper.Map<Villa, VillaResource>(villa);
        }

        [HttpGet("{id}/equipments")]
        public async Task<IEnumerable<EquipmentResource>> VillasEquipments(int id)
        {
            var equipments = await villaService.ListEquipmentsAsync(id, Language);

            return mapper.Map<IEnumerable<Equipment>, IEnumerable<EquipmentResource>>(equipments);
        }

        [HttpGet("{id}/formulas")]
        public async Task<IEnumerable<VillaFormulaResource>> VillasFormulas(int id)
        {
            var villasFormulas = await villaService.ListFormulasAsync(id, Language);

            return mapper.Map<IEnumerable<VillaFormula>, IEnumerable<VillaFormulaResource>>(villasFormulas);
        }

        [HttpGet("{id}/medias")]
        public async Task<IEnumerable<VillaMediaResource>> VillasMedias(int id)
        {
            var villasMedias = await villaService.ListMediasAsync(id, Language);

            return mapper.Map<IEnumerable<VillaMedia>, IEnumerable<VillaMediaResource>>(villasMedias);
        }

        [HttpGet("{id}/booked_dates")]
        public async Task<IEnumerable<DateTime>> VillasBookedDates(int id)
        {
            return await villaService.ListBookedDates(id);
        }

        /*
        [HttpGet("{id}/reservations")]
        public IEnumerable<ReservationResource> VillasReservations(int id)
        {
            var reservations = appDbContext
                .Reservations
                .Where(x => x.VillaId == id)
                .Select(x => new Reservation
                {
                    ReservationId = x.ReservationId,
                    CustomerId = x.CustomerId,
                    VillaId = x.VillaId,
                    FormulaId = x.FormulaId,
                    NumberAdults = x.NumberAdults,
                    NumberChildren = x.NumberChildren,
                    NumberBabies = x.NumberBabies,
                    ReservationDate = x.ReservationDate,
                    ReservationPrice = x.ReservationPrice,
                    PriceChoice = x.PriceChoice,
                    CheckInDate = x.CheckInDate,
                    CheckOutDate = x.CheckOutDate,
                })
                .ToList();

            return mapper.Map<IEnumerable<Reservation>, IEnumerable<ReservationResource>>(reservations);
        }
        */
    }
}