
namespace Solidarize.Common.Request
{
    public class AddSeasonRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Goal { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
