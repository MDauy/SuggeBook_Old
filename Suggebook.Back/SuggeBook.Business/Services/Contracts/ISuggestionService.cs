﻿using SuggeBook.Dto.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuggeBook.Business.Services.Contracts
{
    public interface ISuggestionService
    {
        Task Insert(InsertSuggestionDto dto);
        Task<SuggestionDto> Get(string id);
        Task<List<SuggestionDto>> GetFomBook(string bookId);
        Task<List<SuggestionDto>> GetLastFromBook(string bookId);
        Task<List<SuggestionDto>> GetLastFromAuthor(string authorId);
        Task<List<SuggestionDto>> GetLastFromCategories(List<string> categories);
    }
}