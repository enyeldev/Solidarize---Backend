﻿

namespace Solidarize.Common.Request
{
    public class EditDonationRequest
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public int DonorId { get; set; }
        public int SeasonId { get; set; }
    }
}
