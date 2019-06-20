using SuggeBook.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggeBook.Api.ViewModels
{
    public class RegisterMissedAuthorViewModel
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public string TriedUrl { get; set; }
        public string StatusCode { get; set; }

        public MissedAuthor ToModel ()
        {
            return new MissedAuthor
            {
                Message = Message,
                Name = Name,
                StatusCode = StatusCode,
                TriedUrl = TriedUrl
            };
        }
    }
}
