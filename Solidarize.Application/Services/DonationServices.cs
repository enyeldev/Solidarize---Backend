using Solidarize.Application.Interfaces;
using Solidarize.Common;
using Solidarize.Common.Dto;
using Solidarize.Common.Request;
using Solidarize.Infrastructure.Interfaces;

namespace Solidarize.Application.Services
{
    public class DonationServices : IDonationServices
    {

        private readonly IDonationRepository _repo;

        public DonationServices(IDonationRepository repo)
        {
            _repo = repo;
        }

        public async Task<Response<DonationDto>> AddDonation(AddDonationRequest request)
        {
            if (request.Amount == 0)
            {
                return new Response<DonationDto> { Code = 400, Messages = "El monto no puede ser 0", Succesess = false };
            }

            await _repo.AddDonation(request);

            return new Response<DonationDto> { Code = 200, Messages = "Donation registrado correctamente", Succesess = true };
        }

        public async Task<Response<DonationDto>> DeleteDonation(DeleteDonationRequest request)
        {
            var donationExist = await _repo.GetDonationById(request.Id);

            if (donationExist is null)
            {
                return new Response<DonationDto> { Code = 404, Messages = "No existe esa donacion" };
            }

            await _repo.DeleteDonation(donationExist);

            return new Response<DonationDto> { Code = 200, Messages = "Donacion eliminada correctamente", Succesess = true };
        }

        public async Task<Response<DonationDto>> EditDonation(EditDonationRequest request)
        {
            if (request.Amount == 0)
            {
                return new Response<DonationDto> { Code = 400, Messages = "No existe esa donacion" };
            }

            var donorExist = await _repo.GetDonationById(request.Id);

            if (donorExist is null)
            {
                return new Response<DonationDto> { Code = 404, Messages = "No existe esta donacion" };
            }


            var data = await _repo.EditDonation(request);

            return new Response<DonationDto> { Code = 200, Messages = "Donacion editada correctamente", Succesess = true, Data = data };
        }

        public async Task<Response<List<DonationDto>>> GetDonations()
        {
            var donation = await _repo.GetDonations();

            if (donation.Count() == 0)
            {
                return new Response<List<DonationDto>> { Code = 404, Messages = "No hay donaciones" };
            }

            return new Response<List<DonationDto>> { Code = 200, Messages = "Peticion exitosa", Succesess = true, Data = donation };
        }
    }
}
