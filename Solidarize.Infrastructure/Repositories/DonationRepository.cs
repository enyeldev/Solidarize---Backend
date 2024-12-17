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
            try
            {
                var donation = _mapper.Map<Donations>(request);

                var season = await _context.Season.FirstOrDefaultAsync(e => e.Id == request.SeasonId);

                if (season is null)
                {
                    throw new Exception("No existe esta campaña");
                }

                var newSeasonAmount = season.Amount + donation.Amount;

                if (newSeasonAmount >= season.Goal)
                {
                    season.Active = false;
                }

                season.Amount = newSeasonAmount;

                _context.Season.Update(season);

                await _context.Donation.AddAsync(donation);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task DeleteDonation(DonationDto donationDto)
        {
            try
            {
                var donation = _mapper.Map<Donations>(donationDto);
                donation.Active = false;
                _context.Donation.Update(donation);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DonationDto> EditDonation(EditDonationRequest request)
        {

            try
            {
                var donation = _mapper.Map<Donations>(request);
                var donationEdited = _context.Donation.Update(donation);

                var donationDto = _mapper.Map<DonationDto>(donation);
                await _context.SaveChangesAsync();

                return donationDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public async Task<DonationDto> GetDonationById(int id)
        {
            try
            {
                var donation = await _context.Donation.FirstOrDefaultAsync(e => e.Id == id);

                var donationDto = _mapper.Map<DonationDto>(donation);

                return donationDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<DonationDto>> GetDonations()
        {
            try
            {
                var donationDto = new List<DonationDto>();
                var donations = await _context.Donation.Where(e => e.Active == true).ToListAsync();

                foreach (var item in donations)
                {
                    donationDto.Add(_mapper.Map<DonationDto>(item));
                }

                return donationDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
