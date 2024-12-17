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
    public class DonationControllers : ControllerBase
    {
        private readonly IDonationServices _services;

        public DonationControllers(IDonationServices services)
        {
            _services = services;
        }

        [HttpGet("ObtenerDonaciones")]
        public async Task<ActionResult<Response<List<DonationDto>>>> GetDonations()
        {
           var response = await _services.GetDonations();

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("AgregarDonacion")]
        public async Task<ActionResult<Response<DonationDto>>> AddDonation(AddDonationRequest request)
        {
            var response = await _services.AddDonation(request);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut("EditarDonacion")]
        public async Task<ActionResult<Response<DonationDto>>> EditDonor(EditDonationRequest request)
        {
            var response = await _services.EditDonation(request);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("DeleteDonacion")]
        public async Task<ActionResult<Response<DonationDto>>> DeleteDonation(DeleteDonationRequest request)
        {
            var response = await _services.DeleteDonation(request);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
