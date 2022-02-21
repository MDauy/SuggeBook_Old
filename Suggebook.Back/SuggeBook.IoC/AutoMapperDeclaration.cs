using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SuggeBook.Domain.Model;
using SuggeBook.Infrastructure.Documents;
using SuggeBook.IoC.Profiles;
using SuggeBook.ViewModels;

namespace SuggeBook.IoC
{
    public static class AutoMapperDeclaration
    {
        public static void DeclareMaps(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Oeuvre), typeof(BaseViewModel), typeof(BaseDocument));
            services.AddAutoMapper(typeof(BookProfile), typeof(AuthorProfile), typeof(SuggestionProfile), typeof(UserProfile), typeof(SagaProfile));
        }
    }
}
