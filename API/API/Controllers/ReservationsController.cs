using System;
using System.Threading.Tasks;
using API.Controllers.Response;
using API.Domain.Models;
using API.Domain.Services;
using API.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("reservations")]
    public class ReservationsController : AuthorizeController
    {
        private readonly IReservationService reservationService;
        private readonly IMapper mapper;

        public ReservationsController(IReservationService reservationService, IMapper mapper)
        {
            this.reservationService = reservationService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] NewReservationResource newReservationResource)
        {
            var reservation = mapper.Map<NewReservationResource, Reservation>(newReservationResource);
            reservation.CustomerId = Customer.CustomerId;
            reservation.ReservationDate = DateTime.Now;
            var reservationResponse = await reservationService.SaveAsync(reservation);

            if (!reservationResponse.Success)
                return BadRequest(
                    new VillaHotelApiResponse<bool>(400, reservationResponse.Message)
                );

            return Ok(
                new VillaHotelApiResponse<bool>(true));
        }
    }
}