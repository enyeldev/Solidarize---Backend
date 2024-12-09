
using Solidarize.Common;
using Solidarize.Common.Dto;
using Solidarize.Common.Request;

namespace Solidarize.Application.Interfaces
{
    public interface ISeasonServices
    {
        Task<Response<List<SeasonDto>>> GetSeasons();

        Task<Response<SeasonDto>> AddSeason(AddSeasonRequest request);
        Task<Response<SeasonDto>> EditSeason(EditSeasonRequest request);
        Task<Response<SeasonDto>> DeleteSeason(DeleteSeasonRequest request);
    }
}
