using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Solidarize.Common.Dto;
using Solidarize.Common.Request;
using Solidarize.Domain.Entites.Models;
using Solidarize.Infrastructure.Interfaces;
using Solidarize.Persistence;

namespace Solidarize.Infrastructure.Repositories
{
    public class SeasonRepository : ISeasonRepository
    {
        private readonly SolidarizeDbContext _context;
        private readonly IMapper _mapper;
        public SeasonRepository(SolidarizeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddSeason(AddSeasonRequest request)
        {
            var season = _mapper.Map<Seasons>(request);

            await _context.Season.AddAsync(season);

            //await _context.SaveChangesAsync();
        }

        public async Task DeleteSeason(SeasonDto seasonDto)
        {
            var season = _mapper.Map<Seasons>(seasonDto);
            season.Active = false;
            _context.Season.Update(season);
            await _context.SaveChangesAsync();
        }

        public async Task<SeasonDto> EditSeason(EditSeasonRequest request)
        {
            var season = _mapper.Map<Seasons>(request);
            var seasonEdited = _context.Season.Update(season);

            var seasonDto = _mapper.Map<SeasonDto>(season);
            await _context.SaveChangesAsync();

            return seasonDto;
        }

        public async Task<List<SeasonDto>> GetSeasons()
        {
            var seasonDto = new List<SeasonDto>();
            var seasons = await _context.Season.Where(e => e.Active == true).ToListAsync();

            foreach (var item in seasons)
            {
                seasonDto.Add(_mapper.Map<SeasonDto>(item));
            }

            return seasonDto;
        }

        public async Task<SeasonDto> GetSeasonById(int id)
        {
            var season = await _context.Season.FirstOrDefaultAsync(e => e.Id == id);

            var seasonDto = _mapper.Map<SeasonDto>(season);

            return seasonDto;
        }
    }
}
