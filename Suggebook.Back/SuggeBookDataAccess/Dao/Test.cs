using SuggeBookDAL.DataServices.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuggeBookDAL.Dao
{
    public class AbstractTest<T> : IBaseRepository<T> where T : BaseDao, new()
    {
        public Task<bool> Delete(T dao)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetSeveral(List<string> ids)
        {
            throw new NotImplementedException();
        }

        public Task Insert(T dao)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(T dao)
        {
            throw new NotImplementedException();
        }
    }
}
