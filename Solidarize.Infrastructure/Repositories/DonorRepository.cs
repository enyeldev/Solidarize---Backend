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

            try
            {
                var donor = _mapper.Map<Donors>(request);

                await _context.Donor.AddAsync(donor);

                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteDonor(DeleteDonorRequest request )
        {            
            try
            {

                var donor = await _context.Donor.FirstOrDefaultAsync(e => e.Id == request.Id);

                if (donor is null)
                {
                    throw new Exception("No existe el donante");
                }

                donor.Active = false;
                //_context.Donor.Update(donor);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task EditDonor(EditDonorRequest request)
        {
            try
            {

                var donorExist = await _context.Donor.FirstOrDefaultAsync(e => e.Id == request.Id);

                if (donorExist is null)
                {
                    throw new Exception("No existe el donante");
                }

                var donor = _mapper.Map<Donors>(request);

                donorExist.Name = donor.Name;
                donorExist.Email = donor.Email;
                donorExist.Phone = donor.Phone;
                donorExist.Addres = donor.Addres;

                //var donorEdited = _context.Donor.Update(donor);

                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DonorDto> GetDonorById(int id)
        {
            try
            {
                var donor = await _context.Donor.FirstOrDefaultAsync(e => e.Id == id);

                var donorDto = _mapper.Map<DonorDto>(donor);

                return donorDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<DonorDto>> GetDonors()
        {
            try
            {
                var donorDto = new List<DonorDto>();
                var donors = await _context.Donor.Where(e => e.Active == true).ToListAsync();

                foreach (var item in donors)
                {
                    donorDto.Add(_mapper.Map<DonorDto>(item));
                }

                return donorDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
