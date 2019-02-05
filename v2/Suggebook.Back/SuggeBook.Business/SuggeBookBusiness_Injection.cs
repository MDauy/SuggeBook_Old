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
            services.AddTransient<IInsertSuggestionCommandHandler, InsertSuggestionCommandHandler>();
            services.AddTransient<IInsertBookCommandHandler, InsertBookCommandHandler>();
            services.AddTransient<IInsertAuthorCommandHandler, InsertAuthorCommandHandler>();
            services.AddTransient<IInsertUserCommandHandler, InsertUserCommandHandler>();
            services.AddTransient<IUpdateBookSuggestionsCommandHandler, UpdateBookSuggestionsCommandHandler>();
            services.AddTransient<IUpdateAuthorSuggestionsCommandHandler, UpdateAuthorSuggestionsCommandHandler>();
            #endregion

            #region Interactors
            services.AddTransient<BaseInteractor<SuggestionDao>, SuggestionInteractor>();
            services.AddTransient<ISuggestionInteractor, SuggestionInteractor>();
            services.AddTransient<BaseInteractor<AuthorDao>, AuthorInteractor>();
            services.AddTransient<BaseInteractor<UserDao>, UserInteractor>();
            services.AddTransient<IUserInteractor, UserInteractor>();
            services.AddTransient<BaseInteractor<BookDao>, BookInteractor>();
            services.AddTransient<IBookInteractor, BookInteractor>();
            #endregion

            #region Services
            services.AddTransient<ISuggestionService, SuggestionService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IUserService, UserService>();
            #endregion
        }
    }
}
