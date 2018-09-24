using Microsoft.Extensions.DependencyInjection;
using SuggeBookDAL.Dao;
using SuggeBookDAL.Repositories;

namespace SuggeBookDAL
{
    public static class SuggeBookDAL_Injection
    {
        public static void Add_SuggeBookDAL(this IServiceCollection services)
        {
            services.AddTransient<BaseRepository<BookDao>, BookRepository>();
            services.AddTransient<BaseRepository<UserDao>, UserRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<BaseRepository<SuggestionDao>, SuggestionRepository>();
            services.AddTransient<BaseRepository<AuthorDao>, AuthorRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<ISuggestionRepository, SuggestionRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
        }
    }
}
