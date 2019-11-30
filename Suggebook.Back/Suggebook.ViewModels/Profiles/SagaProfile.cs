using AutoMapper;
using SuggeBook.Domain.Model;
using SuggeBook.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suggebook.ViewModels.Profiles
{
    public class SagaProfile : Profile
    {
        public SagaProfile ()
        {
            CreateMap<Saga, SagaViewModel>();
            CreateMap<SagaViewModel, Saga>();
            CreateMap<CreateSagaViewModel, Saga>();
        }
    }
}
