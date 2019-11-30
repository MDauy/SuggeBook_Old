using AutoMapper;
using MongoDB.Bson;
using SuggeBook.Domain.Model;
using SuggeBook.Infrastructure.Documents;

namespace SuggeBook.Infrastructure.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile ()
        {
            CreateMap<Book, BookDocument>()
                 .ForMember(document => document.Oid, opt => opt.MapFrom(dest => ObjectId.Parse(dest.Id)));;
            CreateMap<BookDocument, Book>()
                .ForMember(author => author.Id, opt => opt.MapFrom(authorDocument => authorDocument.Oid.ToString()));;
        
        }

    }
}
