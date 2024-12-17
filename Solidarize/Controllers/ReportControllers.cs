using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solidarize.Application.Interfaces;
using Solidarize.Common;
using Solidarize.Common.Dto;

namespace Solidarize.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportControllers : ControllerBase
    {
        private readonly IReportServices _services;

        public ReportControllers(IReportServices services)
        {
            _services = services;
        }

        [HttpGet("ObtenerReporte")]
        public async Task<ActionResult<Response<ReportDto>>> GetReport()
        {
            var response = await _services.GenerateReport();

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

    }
}
