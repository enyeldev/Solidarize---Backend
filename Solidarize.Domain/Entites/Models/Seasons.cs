

namespace Solidarize.Domain.Entites.Models
{
    public class Seasons
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public int Goal { get; set; }
        public int Amount { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Active { get; set; } = true;
    }
}
