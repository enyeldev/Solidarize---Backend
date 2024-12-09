
using AutoMapper;
using Solidarize.Common.Dto;
using Solidarize.Common.Request;
using Solidarize.Domain.Entites.Models;

namespace Solidarize.Infrastructure.Mappers
{
    public class DonationMapper : Profile
    {
        public DonationMapper()
        {
            CreateMap<AddDonationRequest, Donations>().ReverseMap();
            CreateMap<Donations, DonationDto>().ReverseMap();
        }
    }
}
