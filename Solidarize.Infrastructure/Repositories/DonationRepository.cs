using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Solidarize.Common.Dto;
using Solidarize.Common.Request;
using Solidarize.Domain.Entites.Models;
using Solidarize.Infrastructure.Interfaces;
using Solidarize.Persistence;

namespace Solidarize.Infrastructure.Repositories
{
    public class DonationRepository : IDonationRepository
    {
        private readonly SolidarizeDbContext _context;
        private readonly IMapper _mapper;
        public DonationRepository(SolidarizeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddDonation(AddDonationRequest request)
        {
            var donation = _mapper.Map<Donations>(request);

            await _context.Donation.AddAsync(donation);

            //await _context.SaveChangesAsync();
        }

        public async Task DeleteDonation(DonationDto donationDto)
        {
            var donation = _mapper.Map<Donations>(donationDto);
            donation.Active = false;
            _context.Donation.Update(donation);
            await _context.SaveChangesAsync();
        }

        public async Task<DonationDto> EditDonation(EditDonationRequest request)
        {
            var donation = _mapper.Map<Donations>(request);
            var donationEdited = _context.Donation.Update(donation);

            var donationDto = _mapper.Map<DonationDto>(donation);
            await _context.SaveChangesAsync();

            return donationDto;
        }

        public async Task<DonationDto> GetDonationById(int id)
        {
            var donation = await _context.Donation.FirstOrDefaultAsync(e => e.Id == id);

            var donationDto = _mapper.Map<DonationDto>(donation);

            return donationDto;
        }

        public async Task<List<DonationDto>> GetDonations()
        {
            var donationDto = new List<DonationDto>();
            var donations = await _context.Donation.Where(e => e.Active == true).ToListAsync();

            foreach (var item in donations)
            {
                donationDto.Add(_mapper.Map<DonationDto>(item));
            }

            return donationDto;
        }
    }
}
