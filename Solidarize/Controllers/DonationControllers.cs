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
            return await _services.GetDonations();
        }

        [HttpPost("AgregarDonacion")]
        public async Task<ActionResult<Response<DonationDto>>> AddDonation(AddDonationRequest request)
        {
            return Ok(await _services.AddDonation(request));
        }

        [HttpPut("EditarDonacion")]
        public async Task<ActionResult<Response<DonationDto>>> EditDonor(EditDonationRequest request)
        {
            return await _services.EditDonation(request);
        }

        [HttpDelete("DeleteDonacion")]
        public async Task<ActionResult<Response<DonationDto>>> DeleteDonation(DeleteDonationRequest request)
        {
            return await _services.DeleteDonation(request);
        }
    }
}
