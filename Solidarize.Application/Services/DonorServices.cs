using Microsoft.IdentityModel.Tokens;
using Solidarize.Application.Interfaces;
using Solidarize.Common;
using Solidarize.Common.Dto;
using Solidarize.Common.Request;
using Solidarize.Infrastructure.Interfaces;

namespace Solidarize.Application.Services
{
    public class DonorServices : IDonorServices
    {
        private readonly IDonorRepository _repo;

        public DonorServices(IDonorRepository repo)
        {
            _repo = repo;
        }

        public async Task<Response<List<DonorDto>>> AddDonor(AddDonorRequest request)
        {
            try
            {
                if (request.Name.IsNullOrEmpty() || request.Email.IsNullOrEmpty() || request.Phone.IsNullOrEmpty() || request.Addres.IsNullOrEmpty())
                {
                    return new Response<List<DonorDto>> { Code = 400, Message = "Todos los campos son obligatorios", Success = false };
                }

                await _repo.AddDonor(request);

                var donorsDtoList = await _repo.GetDonors();

                return new Response<List<DonorDto>> { Code = 200, Message = "Donante registrado correctamente", Success = true, Data = donorsDtoList };
            } catch (Exception ex)
            {
                return new Response<List<DonorDto>> { Code = 400, Message = ex.Message, Success = false };
            }

        }

        public async Task<Response<List<DonorDto>>> DeleteDonor(DeleteDonorRequest request)
        {           
            try
            {
                await _repo.DeleteDonor(request);

                var donorsDtoList = await _repo.GetDonors();

                return new Response<List<DonorDto>> { Code = 200, Message = "Donante eliminado correctamente", Success = true, Data = donorsDtoList };

            } catch (Exception ex)
            {
                return new Response<List<DonorDto>> { Code = 400, Message = ex.Message, Success = false };
            }
        }

        public async Task<Response<List<DonorDto>>> EditDonor(EditDonorRequest request)
        {

            try
            {
                if (request.Name.IsNullOrEmpty() || request.Phone.IsNullOrEmpty() || request.Email.IsNullOrEmpty() || request.Addres.IsNullOrEmpty())
                {
                    return new Response<List<DonorDto>> { Code = 400, Message = "Todos los campos son obligatorios" };
                }

                
                await _repo.EditDonor(request);

                var donorsDtoList = await _repo.GetDonors();

                return new Response<List<DonorDto>> { Code = 200, Message = "Donante editado correctamente", Success = true, Data = donorsDtoList };
            } catch (Exception ex) 
            {
                return new Response<List<DonorDto>> { Code = 400, Message = ex.Message, Success = false };
            }

        }

        public async Task<Response<List<DonorDto>>> GetDonors()
        {
            try
            {
                var donors = await _repo.GetDonors();

                if (donors.Count() == 0)
                {
                    return new Response<List<DonorDto>> { Code = 404, Message = "No hay donnates" };
                }

                return new Response<List<DonorDto>> { Code = 200, Message = "Lista de donantes", Success = true, Data = donors };
            } catch (Exception ex)
            {
                return new Response<List<DonorDto>> { Code = 400, Message = ex.Message, Success = false };
            }

        }
    }
}
