using Solidarize.Common.Dto;
using Solidarize.Common.Request;


namespace Solidarize.Infrastructure.Interfaces
{
    public interface ISeasonRepository
    {
        Task<List<SeasonDto>> GetSeasons();

        Task AddSeason(AddSeasonRequest request);

        Task<SeasonDto> GetSeasonById(int id);

        Task<SeasonDto> EditSeason(EditSeasonRequest request);

        Task DeleteSeason(SeasonDto seasonDto);
    }
}
