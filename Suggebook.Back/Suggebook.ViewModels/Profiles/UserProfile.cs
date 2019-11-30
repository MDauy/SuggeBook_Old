using AutoMapper;
using SuggeBook.Domain.Model;
using SuggeBook.ViewModels;

namespace Suggebook.ViewModels.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserViewModel, User>();
            CreateMap<User, UserViewModel>();
            CreateMap<CreateUserViewModel, User>();
        }
    }
}
