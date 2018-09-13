using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using SuggeBookDAL.Dao;

namespace SuggeBookDAL.Repositories
{
    public class BaseRepository<T> where T : BaseDao, new()
    {
        protected IMongoCollection<T> _collection;
        protected IMongoDatabase _db;
        protected string _collectionName;

        public string GetCollectionName(BaseDao dao)
        {
            switch (dao)
            {
                case SuggestionDao o:
                    return "Suggestions";
                case AuthorDao o:
                    return "Authors";
                case UserDao o:
                    return "Users";
                case BookDao o:
                default:
                    return "Books";

            }
        }
        public IMongoCollection<T> Collection
        {
            get
            {
                if (_collection == null)
                {
                    _collection = _db.GetCollection<T>(_collectionName);
                    if (_collection == null)
                    {
                        _db.CreateCollection(_collectionName);
                    }
                }
                return _collection;

            }
        }

        public BaseRepository()
        {
            _db = DataBaseAccess.Db;
            this._collectionName = GetCollectionName(new T());
        }

        public async Task<T> Get(string id)
        {
            try
            {
                var dao = await Collection.FindAsync<T>(d => d.Id == ObjectId.Parse(id));
                return dao.FirstOrDefault();
            }
            catch (Exception)
            {
                throw new Exception(string.Format("L'objet dans la collection {0} avec l'id {1} n'a pas été trouvé", _collectionName, id));
            }
        }

        public async Task Insert(T dao)
        {
            try
            {
                await Collection.InsertOneAsync(dao);
            }
            catch (Exception e)
            {
                throw e;
            }
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
                throw new Exception(string.Format("Update with {0} {1} went wrong : maybe not found or two many suggestions with same id", dao.GetType().ToString(), dao.Id));
            }
        }

        public async Task<List<T>> GetSeveral(List<string> ids)
        {
            var result = new List<T>();

            foreach (var id in ids)
            {
                result.Add(await Get(id));
            }
            return result;
        }

        public async Task<T> GetRandom ()
        {
            var ids = Collection.Distinct<ObjectId>("_id", Builders<T>.Filter.Empty).ToList();
            var index = new Random().Next(1, ids.Count -1 );

            return await Get(ids[index].ToString());
        }

    }
}
