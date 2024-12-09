using Solidarize.Common.Dto;


namespace Solidarize.Infrastructure.Interfaces
{
    public interface IReportRepository
    {
        Task<decimal> GetTotalDonated();

        Task<int> GetTotalDonors();
    }
}
