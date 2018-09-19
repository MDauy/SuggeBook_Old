using System.Linq;
using System.Threading.Tasks;
using SuggeBook.Business.Commands.Contracts;
using SuggeBook.Dto.Models;
using SuggeBookDAL.Dao;
using SuggeBookDAL.Repositories;

namespace SuggeBook.Business.Commands.Implementations
{
    public class InsertBookCommandHandler : IInsertBookCommandHandler
    {
        private BaseRepository<BookDao>  _repo;

        public InsertBookCommandHandler (BaseRepository<BookDao> repo)
        {
            _repo = repo;
        }

        public async Task<bool> ExecuteAsync(InsertBookDto command)
        {
           var bookDao = Framework.CustomAutoMapper.Map<BookDto, BookDao> (command.BookDto);
            bookDao.Categories = command.BookDto.Categories.Select(c => c.ToString()).ToList();
            bookDao.Author = new BookDao.BookDaoAuthor
            {
                Id = new MongoDB.Bson.ObjectId(command.AuthorId),
                FullName = command.BookDto.AuthorFullName
            };
            await _repo.Insert(bookDao);
            return true;
        }
    }
}
