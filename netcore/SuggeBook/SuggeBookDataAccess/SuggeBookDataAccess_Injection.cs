using Microsoft.Extensions.DependencyInjection;
using SuggeBookDataAccess.DataServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBookDataAccess
{
    public static class SuggeBookDataAccess_Injection
    {
        public static void Add_SuggeBookDataAccess(this IServiceCollection services)
        {
            services.AddSingleton<IBookDataService, BookDataService>();
            services.AddSingleton<IUserDataService, UserDataService>();
            services.AddSingleton<ISuggestionDataService, SuggestionDataService>();
        }
    }
}
