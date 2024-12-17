using Microsoft.IdentityModel.Tokens;
using Solidarize.Application.Interfaces;
using Solidarize.Common;
using Solidarize.Common.Dto;
using Solidarize.Common.Request;
using Solidarize.Infrastructure.Interfaces;

namespace Solidarize.Application.Services
{
    public class SeasonServices : ISeasonServices
    {

        private readonly ISeasonRepository _repo;

        public SeasonServices(ISeasonRepository repo)
        {
            _repo = repo;
        }

        public async Task<Response<SeasonDto>> AddSeason(AddSeasonRequest request)
        {
            try
            {
                if (request.Name.IsNullOrEmpty() || request.Description.IsNullOrEmpty() || request.Goal == 0)
                {
                    return new Response<SeasonDto> { Code = 400, Message = "Todos los campos son obligatorios", Success = false };
                }

                await _repo.AddSeason(request);

                return new Response<SeasonDto> { Code = 200, Message = "Campaña registrado correctamente", Success = true };
            } catch (Exception ex)
            {
                return new Response<SeasonDto> { Code = 400, Message = ex.Message, Success = false };
            }
        }

        public async Task<Response<SeasonDto>> DeleteSeason(DeleteSeasonRequest request)
        {
            try
            {
                var seasonExist = await _repo.GetSeasonById(request.Id);

                if (seasonExist is null)
                {
                    return new Response<SeasonDto> { Code = 404, Message = "No existe ese donante" };
                }

                await _repo.DeleteSeason(seasonExist);

                return new Response<SeasonDto> { Code = 200, Message = "Campaña eliminado correctamente", Success = true };

            } catch (Exception ex)
            {
                return new Response<SeasonDto> { Code = 400, Message = ex.Message, Success = false };
            }
        }

        public async Task<Response<SeasonDto>> EditSeason(EditSeasonRequest request)
        {
            try
            {
                if (request.Name.IsNullOrEmpty() || request.Description.IsNullOrEmpty() || request.Goal == 0)
                {
                    return new Response<SeasonDto> { Code = 400, Message = "Todos los campos son obligatorios" };
                }

                var donorExist = await _repo.GetSeasonById(request.Id);

                if (donorExist is null)
                {
                    return new Response<SeasonDto> { Code = 404, Message = "No existe este donante" };
                }


                var data = await _repo.EditSeason(request);

                return new Response<SeasonDto> { Code = 200, Message = "Campaña editada correctamente", Success = true, Data = data };
            } catch (Exception ex)
            {
                return new Response<SeasonDto> { Code = 400, Message = ex.Message, Success = false };
            }
        }

        public async Task<Response<List<SeasonDto>>> GetSeasons()
        {
            try
            {
                var seasons = await _repo.GetSeasons();

                if (!seasons.Any())
                {
                    return new Response<List<SeasonDto>> { Code = 404, Message = "Campañas no encontradas" };
                }

                return new Response<List<SeasonDto>> { Code = 200, Message = "Lista de Campañas", Success = true, Data = seasons };
            } catch (Exception ex)
            {
                return new Response<List<SeasonDto>> { Code = 400, Message = ex.Message, Success = false };
            }
        }
    }
}
