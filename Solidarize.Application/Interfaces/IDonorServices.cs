using Solidarize.Common;
using Solidarize.Common.Dto;
using Solidarize.Common.Request;

namespace Solidarize.Application.Interfaces
{
    public interface IDonorServices
    {

        Task<Response<List<DonorDto>>> GetDonors();

        Task<Response<List<DonorDto>>> AddDonor(AddDonorRequest request);
        Task<Response<List<DonorDto>>> EditDonor(EditDonorRequest request); 
        Task<Response<List<DonorDto>>> DeleteDonor(DeleteDonorRequest request);
    }
}
