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
        public async Task<ActionResult<Response<List<SeasonDto>>>> GetSeasons()
        {
            var response = await _services.GetSeasons();

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }


        [HttpPost("AgregarSeason")]
        public async Task<ActionResult<Response<SeasonDto>>> AddSeason(AddSeasonRequest request)
        {
            var response = await _services.AddSeason(request);
            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut("EditarSeason")]
        public async Task<ActionResult<Response<SeasonDto>>> EditSeason(EditSeasonRequest request)
        {
            var response = await _services.EditSeason(request);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("DeleteSeason")]
        public async Task<ActionResult<Response<SeasonDto>>> DeleteSeason(DeleteSeasonRequest request)
        {
            var response = await _services.DeleteSeason(request);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);


        }

    }
}
