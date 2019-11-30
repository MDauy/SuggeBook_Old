using AutoMapper;
using SuggeBook.Domain.Model;
using SuggeBook.ViewModels;

namespace Suggebook.ViewModels.Profiles
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
