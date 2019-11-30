using AutoMapper;
using MongoDB.Bson;
using SuggeBook.Domain.Model;
using SuggeBook.Infrastructure.Documents;

namespace SuggeBook.Infrastructure.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile ()
        {
            CreateMap <UserDocument, User > ()
                 .ForMember(model => model.Id, opt => opt.MapFrom(dest => dest.Oid.ToString()));
            CreateMap<User, UserDocument>()
                .ForMember(document => document.Oid, opt => opt.MapFrom(dest => ObjectId.Parse(dest.Id)));
        }
    }
}