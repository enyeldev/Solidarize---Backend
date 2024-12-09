

namespace Solidarize.Common.Request
{
    public class AddDonationRequest
    {
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public int DonorId { get; set; }
        public int SeasonId { get; set; }
    }
}
