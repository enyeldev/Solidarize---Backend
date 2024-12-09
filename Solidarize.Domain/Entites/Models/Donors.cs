

namespace Solidarize.Domain.Entites.Models
{
    public class Donors
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Addres { get; set; }
        public bool Active { get; set; } = true;

    }
}
