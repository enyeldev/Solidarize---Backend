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
            try
            {
                if (request.Amount == 0)
                {
                    return new Response<DonationDto> { Code = 400, Message = "El monto no es valido", Success = false };
                }

                await _repo.AddDonation(request);

                return new Response<DonationDto> { Code = 200, Message = "Donation registrado correctamente", Success = true };
            }
            catch (Exception ex)
            {
                return new Response<DonationDto> { Code = 400, Message = ex.Message, Success = false };
            }

        }

        public async Task<Response<DonationDto>> DeleteDonation(DeleteDonationRequest request)
        {
            try
            {
                var donationExist = await _repo.GetDonationById(request.Id);

                if (donationExist is null)
                {
                    return new Response<DonationDto> { Code = 404, Message = "No existe esa donacion" };
                }

                await _repo.DeleteDonation(donationExist);

                return new Response<DonationDto> { Code = 200, Message = "Donacion eliminada correctamente", Success = true };
            }
            catch (Exception ex)
            {
                return new Response<DonationDto> { Code = 400, Message = ex.Message, Success = false };
            }
        }

        public async Task<Response<DonationDto>> EditDonation(EditDonationRequest request)
        {
            try
            {
                if (request.Amount == 0)
                {
                    return new Response<DonationDto> { Code = 400, Message = "Monto no valido" };
                }

                var donorExist = await _repo.GetDonationById(request.Id);

                if (donorExist is null)
                {
                    return new Response<DonationDto> { Code = 404, Message = "No existe esta donacion" };
                }


                var data = await _repo.EditDonation(request);

                return new Response<DonationDto> { Code = 200, Message = "Donacion editada correctamente", Success = true, Data = data };
            }
            catch (Exception ex)
            {
                return new Response<DonationDto> { Code = 400, Message = ex.Message, Success = false };
            }
        }

        public async Task<Response<List<DonationDto>>> GetDonations()
        {

            try
            {
                var donation = await _repo.GetDonations();

                if (donation.Count() == 0)
                {
                    return new Response<List<DonationDto>> { Code = 404, Message = "No hay donaciones" };
                }

                return new Response<List<DonationDto>> { Code = 200, Message = "Peticion exitosa", Success = true, Data = donation };
            }
            catch (Exception ex)
            {
                return new Response<List<DonationDto>> { Code = 400, Message = ex.Message, Success = false };
            }
        }
    }
}
