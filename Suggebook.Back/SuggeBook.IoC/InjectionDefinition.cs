using Microsoft.Extensions.DependencyInjection;
using SuggeBook.Domain.Repositories;
using SuggeBook.Domain.UseCases;
using SuggeBook.Domain.UseCasesInterfaces;
using SuggeBook.Framework;
using SuggeBook.Infrastructure.Documents;
using SuggeBook.Infrastructure.Repositories;

namespace SuggeBook.IoC
{
    public static class InjectionDefinition
    {
        public static void InjectRepositories (this IServiceCollection services)
        {
            services.AddTransient<IBaseRepository<AuthorDocument>, BaseRepository<AuthorDocument>>();
            services.AddTransient<IBaseRepository<BookDocument>, BaseRepository<BookDocument>>();
            services.AddTransient<IBaseRepository<SuggestionDocument>, BaseRepository<SuggestionDocument>>();
            services.AddTransient<IBaseRepository<UserDocument>, BaseRepository<UserDocument>>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<ISuggestionRepository, SuggestionRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
        }

        public static void InjectUseCases(this IServiceCollection services)
        {
            services.AddSingleton<ICreateSuggestion, CreateSuggestion>();
            services.AddSingleton<ICreateUser, CreateUser>();
            services.AddSingleton<ICreateAuthor, CreateAuthor>();
            services.AddSingleton<IGetAuthor, GetAuthor>();
            services.AddSingleton<IGetBook, GetBook>();
            services.AddSingleton<IGetUser, GetUser>();

        }
    }
}
