

using Solidarize.Common;
using Solidarize.Common.Dto;
using Solidarize.Common.Request;

namespace Solidarize.Application.Interfaces
{
    public interface IDonationServices
    {
        Task<Response<List<DonationDto>>> GetDonations();

        Task<Response<DonationDto>> AddDonation(AddDonationRequest request);
        Task<Response<DonationDto>> EditDonation(EditDonationRequest request);
        Task<Response<DonationDto>> DeleteDonation(DeleteDonationRequest request);
    }
}
