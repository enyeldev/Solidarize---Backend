

using Solidarize.Common.Dto;
using Solidarize.Common.Request;

namespace Solidarize.Infrastructure.Interfaces
{
    public interface IDonationRepository
    {
        Task<List<DonationDto>> GetDonations();

        Task AddDonation(AddDonationRequest request);

        Task<DonationDto> GetDonationById(int id);

        Task<DonationDto> EditDonation(EditDonationRequest request);

        Task DeleteDonation(DonationDto donationDto);
    }
}
