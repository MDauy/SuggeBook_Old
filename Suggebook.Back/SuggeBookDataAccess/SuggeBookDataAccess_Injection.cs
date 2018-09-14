using Microsoft.Extensions.DependencyInjection;
using SuggeBookDAL.Dao;
using SuggeBookDAL.Repositories;

namespace SuggeBookDAL
{
    public static class SuggeBookDAL_Injection
    {
        public static void Add_SuggeBookDAL(this IServiceCollection services)
        {
            services.AddSingleton<BaseRepository<BookDao>, BookRepository>();
            services.AddSingleton<BaseRepository<UserDao>, UserRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<BaseRepository<SuggestionDao>, SuggestionRepository>();
            services.AddSingleton<BaseRepository<AuthorDao>, AuthorRepository>();
            services.AddSingleton<ISuggestionRepository, SuggestionRepository>();
        }
    }
}
