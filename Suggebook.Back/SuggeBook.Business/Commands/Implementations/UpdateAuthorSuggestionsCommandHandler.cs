using SuggeBook.Business.Commands.Contracts;
using SuggeBook.Dto.Models;
using SuggeBookDAL.Dao;
using SuggeBookDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuggeBook.Business.Commands.Implementations
{
    public class UpdateAuthorSuggestionsCommandHandler : IUpdateAuthorSuggestionsCommandHandler
    {
        private readonly IAuthorRepository _repo;

        public UpdateAuthorSuggestionsCommandHandler (IAuthorRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> ExecuteAsync(UpdateAuthorSuggestionsDto obj)
        {
            await _repo.UpdateAuthorSuggestions(obj.AuthorId, obj.Suggestion);
            return true;
        }
    }
}
