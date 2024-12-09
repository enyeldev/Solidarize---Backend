namespace Solidarize.Domain.Entites.Models
{
    public class Donations
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }

        public bool Active { get; set; } = true;

        public Donors Donor { get; set; }
        public int DonorId { get; set; }

        public Seasons Season { get; set; }
        public int SeasonId { get; set; }

    }
}
