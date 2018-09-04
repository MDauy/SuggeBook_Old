using System.Threading.Tasks;
using SuggeBook.Business.Commands.Contracts;
using SuggeBook.Dto.Models;
using SuggeBook.Framework;
using SuggeBookDAL.Dao;
using SuggeBookDAL.Repositories.Contracts;

namespace SuggeBook.Business.Commands.Implementations
{
    public class InsertBookCommandHandler : IInsertBookCommandHandler
    {
        private IBookRepository _repo;

        public InsertBookCommandHandler (IBookRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> ExecuteAsync(BookDto obj)
        {
           await _repo.Insert(SuggeBookAutoMapper.Map<BookDto, BookDao> (obj));

            return true;
        }
    }
}
