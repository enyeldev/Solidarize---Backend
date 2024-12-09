using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solidarize.Application.Interfaces;
using Solidarize.Common;
using Solidarize.Common.Dto;
using Solidarize.Common.Request;

namespace Solidarize.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonsController : ControllerBase
    {
        private readonly ISeasonServices _services;

        public SeasonsController(ISeasonServices services)
        {
            _services = services;
        }


        [HttpGet("ObtenerSeasons")]
        public async Task<ActionResult<Response<List<SeasonDto>>>> GetDonors()
        {
            return await _services.GetSeasons();
        }


        [HttpPost("AgregarDonante")]
        public async Task<ActionResult<Response<SeasonDto>>> AddDonor(AddSeasonRequest request)
        {
            return await _services.AddSeason(request);
        }

        [HttpPut("EditarDonante")]
        public async Task<ActionResult<Response<SeasonDto>>> EditDonor(EditSeasonRequest request)
        {
            return await _services.EditSeason(request);
        }

        [HttpDelete("DeleteDonnate")]
        public async Task<ActionResult<Response<SeasonDto>>> DeleteDonor(DeleteSeasonRequest request)
        {
            return await _services.DeleteSeason(request);
        }

    }
}
