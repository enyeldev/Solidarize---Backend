using AutoMapper;
using Solidarize.Common.Dto;
using Solidarize.Common.Request;
using Solidarize.Domain.Entites.Models;


namespace Solidarize.Infrastructure.Mappers
{
    public class SeasonMapper : Profile
    {

        public SeasonMapper()
        {
            CreateMap<AddSeasonRequest, Seasons>().ReverseMap();
            CreateMap<Seasons, SeasonDto>().ReverseMap();
        }

    }
}
