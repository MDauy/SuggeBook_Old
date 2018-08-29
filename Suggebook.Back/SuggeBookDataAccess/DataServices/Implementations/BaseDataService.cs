
using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using SuggeBookDAL.Dao;
using SuggeBookDAL.DataServices.Contracts;

namespace SuggeBookDAL.DataServices.Implementations
{
    public class BaseDataService<T> : IBaseDataService<T> where T : BaseDao
    {
        private IMongoCollection<T> _collection;
        private IMongoDatabase _db;
        private string CollectionName;

        public IMongoCollection<T> Collection
        {
            get
            {
                if (_collection == null)
                {
                    _collection = _db.GetCollection<T>(this.CollectionName);
                    if (_collection == null)
                    {
                        _db.CreateCollection(this.CollectionName);
                    }
                }
                return _collection;

            }
        }

        public BaseDataService(string collection)
        {
            _db = DataBaseAccess.Db;
            this.CollectionName = collection;
        }

        public async Task<T> Get(string id)
        {
            var dao = await Collection.FindAsync<T>(d => d.Id == ObjectId.Parse(id));

            return dao.FirstOrDefault();
        }

        public async Task Insert(T dao)
        {
            await Collection.InsertOneAsync(dao);
        }

        public async Task<bool> Delete(T dao)
        {
            var result = await Collection.DeleteOneAsync(s => s.Id == dao.Id);

            if (result.DeletedCount == 1)
            {
                return true;
            }
            else
            {
                throw new Exception(string.Format("Deletion with {0} {1} went wrong : maybe not found or two many suggestions with same id", dao.GetType().ToString(), dao.Id));
            }
        }

        public async Task<bool> Update(T dao)
        {
            var result = await Collection.ReplaceOneAsync(s => s.Id == dao.Id, dao);

            if (result.IsModifiedCountAvailable && result.ModifiedCount == 1)
            {
                return true;
            }
            else
            {
                throw new Exception(string.Format("Update with suggestion {0} went wrong : maybe not found or two many suggestions with same id", dao.Id));
            }
        }
    }
}
