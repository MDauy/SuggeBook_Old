using AutoMapper;
using MongoDB.Bson;
using SuggeBook.Domain.Model;
using SuggeBook.Infrastructure.Documents;

namespace SuggeBook.Infrastructure.Profiles
{
    public class SagaProfile : Profile
    {
        public SagaProfile ()
        {
            CreateMap<Saga, SagaDocument>()
                .ForMember(document => document.Oid, opt => opt.MapFrom(dest => ObjectId.Parse(dest.Id)));
            CreateMap<SagaDocument, Saga>()
                .ForMember(author => author.Id, opt => opt.MapFrom(authorDocument => authorDocument.Oid.ToString()));;
        }
    }
}
