using Solidarize.Application.Interfaces;
using Solidarize.Common;
using Solidarize.Common.Dto;
using Solidarize.Infrastructure.Interfaces;

namespace Solidarize.Application.Services
{
    public class ReportServices : IReportServices
    {
        private readonly IReportRepository _repo;

        public ReportServices(IReportRepository repo)
        {
            _repo = repo;
        }

        public async Task<Response<ReportDto>> GenerateReport()
        {
            try
            {
                var totalDonations = await _repo.GetTotalDonated();
                var totalDonors = await _repo.GetTotalDonors();

                
                var report = new ReportDto { GenerateDate = DateTime.Now, ReportName = "Reporte De Los Ultimos 30 Dias", TotalDonated = totalDonations, TotalDonors = totalDonors };

                return new Response<ReportDto> { Code = 200, Message = "Reporte listo", Success = true, Data = report };
            } catch (Exception ex)
            {
                return new Response<ReportDto> { Code = 400, Message = ex.Message, Success = false};
            }
        }
    }
}
