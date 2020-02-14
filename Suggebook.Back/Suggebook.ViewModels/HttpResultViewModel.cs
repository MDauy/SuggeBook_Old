using System.Net;

namespace SuggeBook.ViewModels
{
    public class HttpResultViewModel
    {
        public HttpStatusCode HttpStatus { get; set; }

        public string Message { get; set; }

        public HttpResultViewModel (HttpStatusCode httpStatus, string message = "")
        {
            this.HttpStatus = httpStatus;
            this. Message = message;
        }
    }
}
