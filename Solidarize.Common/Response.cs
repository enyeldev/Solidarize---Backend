
namespace Solidarize.Common
{
    public class Response<T> where T: class
    {
        public int Code { get; set; }

        public string Messages { get; set; }

        public bool Succesess { get; set; }

        public T Data { get; set; }
    }
}
