using AutoMapper;
using MongoDB.Bson;
using SuggeBook.Domain.Model;
using SuggeBook.Infrastructure.Documents;
using SuggeBook.ViewModels;
using System.Linq;

namespace SuggeBook.IoC.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDocument>()
                 .ForMember(document => document.Oid, opt => opt.MapFrom(dest => ObjectId.Parse(dest.Id))); ;
            CreateMap<BookDocument, Book>()
                .ForMember(author => author.Id, opt => opt.MapFrom(authorDocument => authorDocument.Oid.ToString())); ;

            CreateMap<CreateBookViewModel, Book>();
            CreateMap<Book, BookViewModel>()
                .ForMember(viewModel => viewModel.Authors, opt => opt.MapFrom(dest => dest.Authors.ToList().Select(a => a.Name)));
            CreateMap<BookViewModel, Book>();

            CreateMap<MissedBookViewModel, MissedBook>();
        }
    }
}
