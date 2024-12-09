

namespace Solidarize.Common.Request
{
    public class EditSeasonRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Goal { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
