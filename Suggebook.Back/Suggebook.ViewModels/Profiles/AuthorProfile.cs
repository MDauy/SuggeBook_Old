using AutoMapper;
using SuggeBook.Domain.Model;
using SuggeBook.ViewModels;

namespace Suggebook.ViewModels.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorViewModel>();
            CreateMap<AuthorViewModel, Author>();
            CreateMap<Author, BookAuthorViewModel>();
            CreateMap<BookAuthorViewModel, Author>();
            CreateMap<CreateAuthorViewModel, Author>();

            CreateMap<MissedAuthorViewModel, MissedAuthor>();
        }
    }
}
