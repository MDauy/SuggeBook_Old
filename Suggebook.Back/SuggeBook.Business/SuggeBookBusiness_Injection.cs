using Microsoft.Extensions.DependencyInjection;
using SuggeBook.Business.Commands.Contracts;
using SuggeBook.Business.Commands.Implementations;
using SuggeBook.Business.Interactors;
using SuggeBook.Business.Services.Contracts;
using SuggeBook.Business.Services.Implementations;
using SuggeBookDAL.Dao;

namespace SuggeBook.Business
{
    public static class SuggeBookBusiness_Injection
    {
        public static void Add_Business(this IServiceCollection services)
        {
            #region Commands
            services.AddSingleton<IInsertSuggestionCommandHandler, InsertSuggestionCommandHandler>();
            services.AddSingleton<IInsertBookCommandHandler, InsertBookCommandHandler>();
            services.AddSingleton<IInsertAuthorCommandHandler, InsertAuthorCommandHandler>();
            services.AddSingleton<IInsertUserCommandHandler, InsertUserCommandHandler>();
            services.AddSingleton<IUpdateBookSuggestionsCommandHandler, UpdateBookSuggestionsCommandHandler>();
            #endregion

            #region Interactors
            services.AddSingleton<BaseInteractor<SuggestionDao>, SuggestionInteractor>();
            services.AddSingleton<ISuggestionInteractor, SuggestionInteractor>();
            services.AddSingleton<BaseInteractor<AuthorDao>, AuthorInteractor>();
            services.AddSingleton<BaseInteractor<UserDao>, UserInteractor>();
            services.AddSingleton<IUserInteractor, UserInteractor>();
            services.AddSingleton<BaseInteractor<BookDao>, BookInteractor>();
            #endregion

            #region Services
            services.AddSingleton<ISuggestionService, SuggestionService>();
            services.AddSingleton<IBookService, BookService>();
            services.AddSingleton<IAuthorService, AuthorService>();
            services.AddSingleton<IUserService, UserService>();
            #endregion
        }
    }
}
