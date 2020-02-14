using AutoMapper;
using SuggeBook.Domain.Model;
using SuggeBook.ViewModels;

namespace Suggebook.ViewModels.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<CreateBookViewModel, Book>();
            CreateMap<Book, BookViewModel>();
            CreateMap<BookViewModel, Book>();

            CreateMap<MissedBookViewModel, MissedBook>();
        }
    }
}
