using Microsoft.Extensions.DependencyInjection;
using SuggeBookDAL.DataServices.Contracts;
using SuggeBookDAL.DataServices.Implementations;

namespace SuggeBookDAL
{
    public static class SuggeBookDAL_Injection
    {
        public static void Add_SuggeBookDAL(this IServiceCollection services)
        {
            services.AddSingleton<IBookDataService, BookDataService>();
            services.AddSingleton<IUserDataService, UserDataService>();
            services.AddSingleton<ISuggestionDataService, SuggestionDataService>();
        }
    }
}
