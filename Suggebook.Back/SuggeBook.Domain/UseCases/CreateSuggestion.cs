﻿using System;
using System.Threading.Tasks;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.Repositories;
using SuggeBook.Domain.UseCasesInterfaces;

namespace SuggeBook.Domain.UseCases
{
    public class CreateSuggestion : ICreateSuggestion
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly ISuggestionRepository _suggestionRepository;

        public CreateSuggestion(IAuthorRepository authorRepository, IBookRepository bookRepository, ISuggestionRepository suggestionRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _suggestionRepository = suggestionRepository;
        }
        public async Task<Suggestion> Create(Suggestion suggestion)
        {
            suggestion.IsValid();

            var createdSuggestion = await _suggestionRepository.Insert(suggestion);
            createdSuggestion.Book = suggestion.Book;
            createdSuggestion.User = suggestion.User;
            foreach (var author in suggestion.Book.Authors)
            {
                 await _authorRepository.UpdateNbSuggestions(author.Id, createdSuggestion.Id);
            }
           
            await _bookRepository.UpdateSuggestions(suggestion.Book.Id, createdSuggestion.Id);

            return createdSuggestion;
        }
    }
}
