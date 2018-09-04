using Microsoft.Extensions.DependencyInjection;
using SuggeBook.Business.Commands.Contracts;
using SuggeBook.Business.Commands.Implementations;
using SuggeBook.Business.Contracts;
using SuggeBook.Business.Implementations;
using SuggeBook.Business.Services.Contracts;
using SuggeBook.Business.Services.Implementations;

namespace SuggeBook.Business
{
    public static class SuggeBookBusiness_Injection
    {
        public static void Add_Business(this IServiceCollection services)
        {
            #region Commands
            services.AddSingleton<IInsertSuggestionCommandHandler, InsertSuggestionCommandHandler>();
            services.AddSingleton<IInsertBookCommandHandler, InsertBookCommandHandler>();
            #endregion

            #region Interactors
            services.AddSingleton<ISuggestionInteractor, SuggestionInteractor>();
            services.AddSingleton<IBookInteractor, BookInteractor>();
            #endregion

            #region Services
            services.AddSingleton<ISuggestionService, SuggestionService>();
            services.AddSingleton<IBookService, BookService>();

            #endregion
        }
    }
}
