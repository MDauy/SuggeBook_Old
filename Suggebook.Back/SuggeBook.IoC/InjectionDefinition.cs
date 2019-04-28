using Microsoft.Extensions.DependencyInjection;
using SuggeBook.Domain.Repositories;
using SuggeBook.Domain.UseCases;
using SuggeBook.Domain.UseCasesInterfaces;
using SuggeBook.Infrastructure.Repositories;

namespace SuggeBook.IoC
{
    public static class InjectionDefinition
    {
        public static void InjectRepositories (this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<ISuggestionRepository, SuggestionRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
        }

        public static void InjectUseCases(this IServiceCollection services)
        {
            services.AddSingleton<ICreateSuggestion, CreateSuggestion>();
            services.AddSingleton<ICreateUser, CreateUser>();
        }
    }
}
