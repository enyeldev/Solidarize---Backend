
namespace Solidarize.Common
{
    public class Response<T> where T: class
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public bool Success { get; set; }

        public T Data { get; set; }

    }
}
