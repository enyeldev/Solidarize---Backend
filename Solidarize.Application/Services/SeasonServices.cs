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
            if (request.Name.IsNullOrEmpty() || request.Description.IsNullOrEmpty() || request.Goal == 0)
            {
                return new Response<SeasonDto> { Code = 400, Messages = "Todos los campos son obligatorios", Succesess = false };
            }

            await _repo.AddSeason(request);

            return new Response<SeasonDto> { Code = 200, Messages = "Campaña registrado correctamente", Succesess = true };
        }

        public async Task<Response<SeasonDto>> DeleteSeason(DeleteSeasonRequest request)
        {
            var seasonExist = await _repo.GetSeasonById(request.Id);

            if (seasonExist is null)
            {
                return new Response<SeasonDto> { Code = 404, Messages = "No existe ese donante" };
            }

            await _repo.DeleteSeason(seasonExist);

            return new Response<SeasonDto> { Code = 200, Messages = "Campaña eliminado correctamente", Succesess = true };
        }

        public async Task<Response<SeasonDto>> EditSeason(EditSeasonRequest request)
        {
            if (request.Name.IsNullOrEmpty() || request.Description.IsNullOrEmpty() || request.Goal == 0)
            {
                return new Response<SeasonDto> { Code = 400, Messages = "Todos los campos son obligatorios" };
            }

            var donorExist = await _repo.GetSeasonById(request.Id);

            if (donorExist is null)
            {
                return new Response<SeasonDto> { Code = 404, Messages = "No existe este donante" };
            }


            var data = await _repo.EditSeason(request);

            return new Response<SeasonDto> { Code = 200, Messages = "Campaña editada correctamente", Succesess = true, Data = data };
        }

        public async Task<Response<List<SeasonDto>>> GetSeasons()
        {
            var seasons = await _repo.GetSeasons();

            if (seasons.Any())
            {
                return new Response<List<SeasonDto>> { Code = 404, Messages = "Campañas no encontradas" };
            }

            return new Response<List<SeasonDto>> { Code = 200, Messages = "Lista de Campañas", Succesess = true, Data = seasons };
        }
    }
}
