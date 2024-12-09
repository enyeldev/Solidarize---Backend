

using Solidarize.Common;
using Solidarize.Common.Dto;

namespace Solidarize.Application.Interfaces
{
    public interface IReportServices
    {
        Task<Response<ReportDto>> GenerateReport();
    }
}
