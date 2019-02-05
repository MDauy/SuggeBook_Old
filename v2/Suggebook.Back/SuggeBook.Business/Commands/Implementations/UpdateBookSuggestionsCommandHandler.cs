using SuggeBook.Business.Commands.Contracts;
using SuggeBook.Dto.Models;
using SuggeBookDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuggeBook.Business.Commands.Implementations
{
    public class UpdateBookSuggestionsCommandHandler : IUpdateBookSuggestionsCommandHandler
    {
        private readonly IBookRepository _repo;

        public UpdateBookSuggestionsCommandHandler(IBookRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> ExecuteAsync(UpdateBookSuggestionsDto obj)
        {
            await _repo.UpdateSuggestions(obj.BookId, obj.Suggestion);

            return true;
        }
    }
}
