using Microsoft.Extensions.DependencyInjection;
using SuggeBookDAL.Repositories.Contracts;
using SuggeBookDAL.Repositories.Implementations;

namespace SuggeBookDAL
{
    public static class SuggeBookDAL_Injection
    {
        public static void Add_SuggeBookDAL(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddSingleton<IBookRepository, BookRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<ISuggestionRepository, SuggestionRepository>();
            services.AddSingleton<IAuthorRepository, AuthorRepository>();
        }
    }
}
