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
    public class UpdateAuthorSuggestionsCommandHandler : IUpdateAuthorSuggestionsCommandaHandler
    {
        private readonly IAuthorRepository _repo;

        public UpdateAuthorSuggestionsCommandHandler (IAuthorRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> ExecuteAsync(UpdateAuthorSuggestionsDto obj)
        {
            return true;
        }
    }
}
