using Solidarize.Common.Dto;
using Solidarize.Common.Request;

namespace Solidarize.Infrastructure.Interfaces
{
    public interface IDonorRepository
    {

        Task<List<DonorDto>> GetDonors();

        Task AddDonor(AddDonorRequest request);

        Task<DonorDto> GetDonorById(int id);

        Task<DonorDto> EditDonor(EditDonorRequest request);

        Task DeleteDonor(DonorDto donorDto);

    }
}
