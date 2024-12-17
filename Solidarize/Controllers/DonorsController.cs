using Microsoft.AspNetCore.Mvc;
using Solidarize.Application.Interfaces;
using Solidarize.Common;
using Solidarize.Common.Dto;
using Solidarize.Common.Request;

namespace Solidarize.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorsController : ControllerBase
    {
        private readonly IDonorServices _services;

        public DonorsController(IDonorServices services)
        {
            _services = services;
        }


        [HttpGet("ObtenerDonantes")]
        public async Task<ActionResult<Response<List<DonorDto>>>> GetDonors()
        {
            var response = await _services.GetDonors();

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }


        [HttpPost("AgregarDonante")]
        public async Task<ActionResult<Response<DonorDto>>> AddDonor(AddDonorRequest request)
        {
            var response = await _services.AddDonor(request);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut("EditarDonante")]
        public async Task<ActionResult<Response<DonorDto>>> EditDonor(EditDonorRequest request)
        {
            var response = await _services.EditDonor(request);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("DeleteDonnate")]
        public async Task<ActionResult<Response<DonorDto>>> DeleteDonor(DeleteDonorRequest request)
        {
            var response = await _services.DeleteDonor(request);
            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

    }
}
