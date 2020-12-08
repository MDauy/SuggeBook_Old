using AutoMapper;
using SuggeBook.Domain.Model;
using SuggeBook.ViewModels;

namespace SuggeBook.IoC.Profiles
{
    public class SuggestionProfile : Profile
    {
        public SuggestionProfile()
        {
            CreateMap<CreateSuggestionViewModel, Suggestion>();
            CreateMap<Suggestion, SuggestionViewModel>();
            CreateMap<SuggestionViewModel, Suggestion>();
        }
    }
}
