using System.Net;

namespace Api.Infrastructure.Errors
{
    public class Error
    {
        public string Code { get; }
        public string Message { get; }
        public HttpStatusCode StatusCode { get; }

        public Error(string code, string message, HttpStatusCode statusCode)
        {
            Code = code;
            Message = message;
            StatusCode = statusCode;
        }
    }
}