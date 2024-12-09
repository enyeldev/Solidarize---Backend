using AutoMapper;
using Solidarize.Common.Dto;
using Solidarize.Common.Request;
using Solidarize.Domain.Entites.Models;


namespace Solidarize.Infrastructure.Mappers
{
    public class DonorMapper : Profile
    {
        public DonorMapper()
        {
            CreateMap<AddDonorRequest, Donors>().ReverseMap();
            CreateMap<Donors, DonorDto>().ReverseMap();
        }
    }
}
