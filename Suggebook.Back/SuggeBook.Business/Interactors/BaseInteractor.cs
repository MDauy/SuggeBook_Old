using SuggeBookDAL.Dao;
using SuggeBookDAL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuggeBook.Business.Interactors
{
    public abstract class BaseInteractor<T> : IBaseInteractor<T> where T : BaseDocument, new()
    {
        protected BaseRepository<T> _repo;

        public virtual async Task<T> Get(string id)
        {
            return await _repo.Get(id);

        }

        public async Task<List<T>> GetSeveral(List<string> ids)
        {
            return await _repo.GetSeveral(ids);
        }

        public async Task<T> GetRandom()
        {
            return await _repo.GetRandom();
        }
    }
}
