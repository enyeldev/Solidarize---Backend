using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Solidarize.Common.Dto;
using Solidarize.Common.Request;
using Solidarize.Domain.Entites.Models;
using Solidarize.Infrastructure.Interfaces;
using Solidarize.Persistence;


namespace Solidarize.Infrastructure.Repositories
{
    public class DonorRepository : IDonorRepository
    {
        private readonly SolidarizeDbContext _context;
        private readonly IMapper _mapper;
        public DonorRepository(SolidarizeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddDonor(AddDonorRequest request)
        {

            var donor = _mapper.Map<Donors>(request);

            await _context.Donor.AddAsync(donor);

            //await _context.SaveChangesAsync();
        }

        public async Task DeleteDonor(DonorDto donorDto)
        {
            var donor = _mapper.Map<Donors>(donorDto);
            donor.Active = false;
            _context.Donor.Update(donor);
            await _context.SaveChangesAsync();
        }

        public async Task<DonorDto> EditDonor(EditDonorRequest request)
        {
            var donor = _mapper.Map<Donors>(request);
            var donorEdited = _context.Donor.Update(donor);

            var donorDto = _mapper.Map<DonorDto>(donor);
            await _context.SaveChangesAsync();

            return donorDto;
        }

        public async Task<DonorDto> GetDonorById(int id)
        {
            var donor = await _context.Donor.FirstOrDefaultAsync(e => e.Id == id);

            var donorDto = _mapper.Map<DonorDto>(donor);

            return donorDto;   
        }

        public async Task<List<DonorDto>> GetDonors()
        {
            var donorDto = new List<DonorDto>();
            var donors = await _context.Donor.Where(e => e.Active == true).ToListAsync();

            foreach (var item in donors)
            {
                donorDto.Add(_mapper.Map<DonorDto>(item));
            }

            return donorDto;
        }
    }
}
