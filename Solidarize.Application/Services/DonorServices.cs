using Microsoft.IdentityModel.Tokens;
using Solidarize.Application.Interfaces;
using Solidarize.Common;
using Solidarize.Common.Dto;
using Solidarize.Common.Request;
using Solidarize.Infrastructure.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace Solidarize.Application.Services
{
    public class DonorServices : IDonorServices
    {
        private readonly IDonorRepository _repo;

        public DonorServices(IDonorRepository repo)
        {
            _repo = repo;
        }

        public async Task<Response<DonorDto>> AddDonor(AddDonorRequest request)
        {
            if (request.Name.IsNullOrEmpty() || request.Email.IsNullOrEmpty() || request.Phone.IsNullOrEmpty() || request.Addres.IsNullOrEmpty())
            {
                return new Response<DonorDto> { Code = 400 , Messages = "Todos los campos son obligatorios" , Succesess = false};
            }

            await _repo.AddDonor(request);

            return new Response<DonorDto> { Code = 200, Messages = "Donante registrado correctamente", Succesess = true };

        }

        public async Task<Response<DonorDto>> DeleteDonor(DeleteDonorRequest request)
        {
            var donorExist = await _repo.GetDonorById(request.Id);

            if (donorExist is null)
            {
                return new Response<DonorDto> { Code = 404, Messages = "No existe ese donante" };
            }

            await _repo.DeleteDonor(donorExist);

            return new Response<DonorDto> { Code = 200, Messages = "Donante eliminado correctamente", Succesess = true };
    
        }

        public async Task<Response<DonorDto>> EditDonor(EditDonorRequest request)
        {

            if (request.Name.IsNullOrEmpty() || request.Phone.IsNullOrEmpty() || request.Email.IsNullOrEmpty() || request.Addres.IsNullOrEmpty())
            {
                return new Response<DonorDto> { Code = 400, Messages = "Todos los campos son obligatorios" };
            }

            var donorExist = await _repo.GetDonorById(request.Id);

            if (donorExist is null)
            {
                return new Response<DonorDto> { Code = 404, Messages = "No existe este donante" };
            }


            var data = await _repo.EditDonor(request);

            return new Response<DonorDto> { Code = 200, Messages = "Donante editado correctamente", Succesess = true, Data = data };

        }

        public async Task<Response<List<DonorDto>>> GetDonors()
        {
            var donors = await _repo.GetDonors();

            if (donors.Any())
            {
                return new Response<List<DonorDto>> { Code = 404, Messages = "No hay donnates" };
            }

            return new Response<List<DonorDto>> { Code = 200, Messages = "Lista de donantes", Succesess = true, Data = donors };

        }
    }
}
