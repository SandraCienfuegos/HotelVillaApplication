using System;
using System.Threading.Tasks;
using API.Domain.Models;
using API.Domain.Repositories;
using API.Domain.Services;
using API.Domain.Services.Communication;
using API.Hubs;
using API.Resources;
using AutoMapper;
using Microsoft.AspNetCore.SignalR;

namespace API.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IMapper mapper;
        private readonly IHubContext<ReservationHub, IReservationHub> hubContext;
        private readonly IReservationRepository reservationRepository;
        private readonly IUnitOfWork unitOfWork;

        public ReservationService(
            IMapper mapper,
            IHubContext<ReservationHub, IReservationHub> hubContext,
            IReservationRepository reservationRepository,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.hubContext = hubContext;
            this.reservationRepository = reservationRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ReservationResponse> SaveAsync(Reservation reservation)
        {
            try
            {
                await reservationRepository.AddAsync(reservation);
                await unitOfWork.CompleteAsync();
                var reservationResource = mapper.Map<Reservation, ReservationResource>(reservation);
                await hubContext.Clients.All.BroadCastReservation(reservationResource);
                return new ReservationResponse(reservation);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException?.Message);
                return new ReservationResponse($"An error occurred when saving the reservation: {e.Message}");
            }
        }
    }
}