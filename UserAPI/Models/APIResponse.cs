using System.Net;

namespace UserAPI.Models
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string> ErrorsMessages { get; set; } = new List<string>();
        public object Result { get; set; }

    }
}
