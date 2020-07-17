using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Models;
using API.Domain.Repositories;
using API.Domain.Services;
using API.Extensions;

namespace API.Services
{
    public class VillaService : IVillaService
    {
        private readonly IEquipmentRepository equipmentRepository;
        private readonly IFormulaRepository formulaRepository;
        private readonly IVillaMediaRepository villaMediaRepository;
        private readonly IVillaRepository villaRepository;

        public VillaService(
            IEquipmentRepository equipmentRepository,
            IFormulaRepository formulaRepository,
            IVillaMediaRepository villaMediaRepository,
            IVillaRepository villaRepository
        )
        {
            this.equipmentRepository = equipmentRepository;
            this.formulaRepository = formulaRepository;
            this.villaMediaRepository = villaMediaRepository;
            this.villaRepository = villaRepository;
        }

        public Task<IEnumerable<Villa>> ListAsync(string language)
        {
            return villaRepository.ListAsync(language);
        }

        public Task<Villa> FindById(int villaId, string language)
        {
            return villaRepository.FindByIdAsync(villaId, language);
        }

        public Task<IEnumerable<Equipment>> ListEquipmentsAsync(int villaId, string language)
        {
            return equipmentRepository.ListEquipmentByVillaIdAsync(villaId, language);
        }

        public Task<IEnumerable<VillaFormula>> ListFormulasAsync(int villaId, string language)
        {
            return formulaRepository.ListFormulaByVillaIdAsync(villaId, language);
        }

        public Task<IEnumerable<VillaMedia>> ListMediasAsync(int villaId, string language)
        {
            return villaMediaRepository.ListMediaByVillaIdAsync(villaId, language);
        }

        public async Task<IEnumerable<DateTime>> ListBookedDates(int id)
        {
            var reservations = await villaRepository.ListReservations(id);
            var bookedDates = new List<DateTime>();

            foreach (var reservation in reservations)
                bookedDates.AddRange(reservation.CheckInDate.Range(reservation.CheckOutDate));

            return bookedDates;
        }
    }
}