using AutoMapper;
using SuggeBook.Domain.Model;
using SuggeBook.ViewModels;
using System.Linq;

namespace Suggebook.ViewModels.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<CreateBookViewModel, Book>();
            CreateMap<Book, BookViewModel>()
                .ForMember(viewModel => viewModel.Authors, opt => opt.MapFrom(dest => dest.Authors.ToList().Select(a => a.Name)));
            CreateMap<BookViewModel, Book>();

            CreateMap<MissedBookViewModel, MissedBook>();
        }
    }
}
