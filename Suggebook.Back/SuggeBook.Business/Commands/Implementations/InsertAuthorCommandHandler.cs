using SuggeBook.Business.Commands.Contracts;
using SuggeBookDAL.Dao;
using SuggeBookDAL.Repositories.Contracts;
using System;
using System.Threading.Tasks;

namespace SuggeBook.Business.Commands.Implementations
{
    public class InsertAuthorCommandHandler : IInsertAuthorCommandHandler
    {
        private readonly IAuthorRepository _repo;
        public InsertAuthorCommandHandler (IAuthorRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> ExecuteAsync(AuthorDao obj)
        {
            await _repo.Insert(obj);
            return true;
        }
    }
}
