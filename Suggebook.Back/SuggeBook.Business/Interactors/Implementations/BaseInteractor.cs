using SuggeBook.Dto.Models;
using SuggeBook.Framework;
using SuggeBookDAL.Dao;
using SuggeBookDAL.Repositories.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuggeBook.Business.Contracts
{
    public abstract class BaseInteractor<T1,T2> where T1 : BaseDao, new() where T2 : BaseDto, new ()
    {
        protected IBaseRepository<T1> _repo;

        public virtual async Task<T2> Get(string id)
        {
            var dao = await _repo.Get(id);
            return SuggeBookAutoMapper.Map<T1, T2>(dao);

        }

        public async Task<List<T2>> GetSeveral (List<string> ids)
        {
            var daos = await _repo.GetSeveral(ids);
            return SuggeBookAutoMapper.MapLists<T1, T2>(daos);
        }
    }
}
