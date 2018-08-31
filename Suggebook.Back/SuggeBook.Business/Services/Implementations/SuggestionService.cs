using SuggeBook.Business.Commands.Contracts;
using SuggeBook.Business.Services.Contracts;
using SuggeBook.Dto.Models;
using SuggeBook.Framework;
using SuggeBookDAL.Dao;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuggeBook.Business.Services.Implementations
{
    public class SuggestionService : ISuggestionService
    {
        private readonly IInsertSuggestionCommandHandler _insertCommand;

        public SuggestionService (IInsertSuggestionCommandHandler insertCommand)
        {
            _insertCommand = insertCommand;
        }

        public async Task Insert(InsertSuggestionDto dto)
        {
            await _insertCommand.ExecuteAsync(dto.Suggestion);
        }
    }
}
