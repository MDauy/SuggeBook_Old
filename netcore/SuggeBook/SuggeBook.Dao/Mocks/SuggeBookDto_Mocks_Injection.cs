using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Dto.Mocks
{
    public static class SuggeBookDto_Mocks_Injection
    {
        public static void Add_MocksServices (this IServiceCollection services)
        {
            services.AddSingleton<IFakeAuthorService, FakeAuthorService>();
            services.AddSingleton<IFakeBooksService, FakeBooksService>();
            services.AddSingleton<IFakeSuggestionsService, FakeSuggestionsService>();
            services.AddSingleton<IFakeUserService, FakeUserService>();
            services.AddSingleton<ITestsBank, TestsBank>();
        }
    }
}
