using System.Collections.Generic;
using System.Threading.Tasks;
using SuggeBookDAL.Dao;
using SuggeBookDAL.Repositories;

namespace SuggeBook.Business.Interactors
{
    public class BookInteractor : BaseInteractor<BookDao>, IBookInteractor
    {
        private readonly IBookRepository _extraRepo;

        public BookInteractor(BaseRepository<BookDao> repo, IBookRepository extraRepo)
        {
            _repo = repo;
            _extraRepo = extraRepo;
        }

        public Task<List<BookDao>> GetFromAuthor(string authorId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<BookDao>> GetFromCategories(List<string> categories)
        {
            return _extraRepo.GetFromCategories(categories);
        }
    }
}
