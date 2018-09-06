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

        public async Task<bool> ExecuteAsync(InsertBookCommandRequest command)
        {
           var bookDao = SuggeBookAutoMapper.Map<BookDto, BookDao> (command.BookDto);
            bookDao.AuthorId = command.AuthorId;
            await _repo.Insert(bookDao);
            return true;
        }
    }
}
