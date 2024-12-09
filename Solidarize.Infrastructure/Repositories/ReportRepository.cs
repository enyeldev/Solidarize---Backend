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
            var startDate = DateTime.Now.AddDays(-30);

            return await _context.Donation.Where(d => d.Date >= startDate).SumAsync(d => d.Amount);
        }

        public async Task<int> GetTotalDonors()
        {
            var startDate = DateTime.Now.AddDays(-30);
            return await _context.Donation.Where(d => d.Date >= startDate).Select(d => d.DonorId).Distinct().CountAsync();

        }
    }
}
