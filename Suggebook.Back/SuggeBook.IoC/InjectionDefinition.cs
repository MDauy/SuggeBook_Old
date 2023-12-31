﻿using Microsoft.Extensions.DependencyInjection;
using SuggeBook.Domain.Repositories;
using SuggeBook.Domain.UseCases;
using SuggeBook.Domain.UseCasesInterfaces;
using SuggeBook.Framework;
using SuggeBook.Infrastructure;
using SuggeBook.Infrastructure.Documents;
using SuggeBook.Infrastructure.Repositories;

namespace SuggeBook.IoC
{
    public static class InjectionDefinition
    {
        public static void InjectBaseRepositories(this IServiceCollection services)
        {
            services.AddTransient<IBaseRepository<AuthorDocument>, BaseRepository<AuthorDocument>>();
            services.AddTransient<IBaseRepository<BookDocument>, BaseRepository<BookDocument>>();
            services.AddTransient<IBaseRepository<SuggestionDocument>, BaseRepository<SuggestionDocument>>();
            services.AddTransient<IBaseRepository<UserDocument>, BaseRepository<UserDocument>>();
            services.AddTransient<IBaseRepository<SagaDocument>, BaseRepository<SagaDocument>>();
            services.AddTransient<IBaseRepository<MissedAuthorDocument>, BaseRepository<MissedAuthorDocument>>();
            services.AddTransient<IBaseRepository<MissedSagaDocument>,
            BaseRepository<MissedSagaDocument>>();
            services.AddTransient<IBaseRepository<MissedBookDocument>,
            BaseRepository<MissedBookDocument>>();
        }

        public static void InjectRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<ISuggestionRepository, SuggestionRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<ISagaRepository, SagaRepository>();
            services.AddTransient<IMissedAuthorRepository, MissedAuthorRepository>();
            services.AddTransient<IMissedSagaRepository, MissedSagaRepository>();
            services.AddTransient<IMissedBookRepository, MissedBookRepository>();
        }

        public static void InjectUseCases(this IServiceCollection services)
        {
            services.AddSingleton<ICreateSuggestion, CreateSuggestion>();
            services.AddSingleton<ICreateUser, CreateUser>();
            services.AddSingleton<ICreateAuthor, CreateAuthor>();
            services.AddSingleton<ICreateBook, CreateBook>();
            services.AddSingleton<IGetAuthor, GetAuthor>();
            services.AddSingleton<IGetBook, GetBook>();
            services.AddSingleton<IGetUser, GetUser>();
            services.AddSingleton<IGetHomeBooks, GetHomeBooks>();
            services.AddSingleton<ICreateSaga, CreateSaga>();
            services.AddSingleton<IRegisterMissedAuthor, RegisterMissedAuthor>();
            services.AddSingleton<IGetSaga, GetSaga>();
            services.AddSingleton<IRegisterMissedSaga, RegisterMissedSaga>();
            services.AddSingleton<IRegisterMissedBook, RegisterMissedBook>();
        }
    }
}
