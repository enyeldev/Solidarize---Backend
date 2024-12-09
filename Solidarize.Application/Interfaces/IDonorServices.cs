using Solidarize.Common;
using Solidarize.Common.Dto;
using Solidarize.Common.Request;

namespace Solidarize.Application.Interfaces
{
    public interface IDonorServices
    {

        Task<Response<List<DonorDto>>> GetDonors();

        Task<Response<DonorDto>> AddDonor(AddDonorRequest request);
        Task<Response<DonorDto>> EditDonor(EditDonorRequest request);
        Task<Response<DonorDto>> DeleteDonor(DeleteDonorRequest request);
    }
}
