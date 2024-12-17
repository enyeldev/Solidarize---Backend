using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Solidarize.Infrastructure.Interfaces;
using Solidarize.Persistence;

namespace Solidarize.Infrastructure.Repositories
{
    public class ReportRepository : IReportRepository
    {

        private readonly SolidarizeDbContext _context;
        private readonly IMapper _mapper;
        public ReportRepository(SolidarizeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<decimal> GetTotalDonated()
        {
            try
            {
                var startDate = DateTime.Now.AddDays(-30);

                return await _context.Donation.Where(d => d.Date >= startDate).SumAsync(d => d.Amount);
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> GetTotalDonors()
        {
            try
            {
                var startDate = DateTime.Now.AddDays(-30);
                return await _context.Donation.Where(d => d.Date >= startDate).Select(d => d.DonorId).Distinct().CountAsync();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
