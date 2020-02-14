using AutoMapper;
using SuggeBook.Domain.Model;
using SuggeBook.ViewModels;

namespace Suggebook.ViewModels.Profiles
{
    public class SagaProfile : Profile
    {
        public SagaProfile ()
        {
            CreateMap<Saga, SagaViewModel>();
            CreateMap<SagaViewModel, Saga>();
            CreateMap<CreateSagaViewModel, Saga>();
            CreateMap<MissedSagaViewModel, MissedSaga>();
        }
    }
}
