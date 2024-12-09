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
            return await _services.GetDonors();
        }


        [HttpPost("AgregarDonante")]
        public async Task<ActionResult<Response<DonorDto>>> AddDonor(AddDonorRequest request)
        {
            return await _services.AddDonor(request);
        }

        [HttpPut("EditarDonante")]
        public async Task<ActionResult<Response<DonorDto>>> EditDonor(EditDonorRequest request)
        {
            return await _services.EditDonor(request);
        }

        [HttpDelete("DeleteDonnate")]
        public async Task<ActionResult<Response<DonorDto>>> DeleteDonor(DeleteDonorRequest request)
        {
            return await _services.DeleteDonor(request);
        }

    }
}
