
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using SuggeBook.Infrastructure;
using SuggeBookDAL.Persistence.Documents;

namespace SuggeBookDAL.Persistence
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseDocument, new()
    {
        protected IMongoCollection<T> _collection;
        protected IMongoDatabase _db;
        protected string _collectionName;

        public string GetCollectionName(BaseDocument dao)
        {
            switch (dao)
            {
                case SuggestionDocument o:
                    return "Suggestions";
                case AuthorDocument o:
                    return "Authors";
                case UserDocument o:
                    return "Users";
                case BookDocument o:
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

        public async Task<T> Get(ObjectId id)
        {
            try
            {
                var dao = await Collection.FindAsync<T>(d => d.Id == id);
                return dao.FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, new Exception (string.Format("L'objet dans la collection {0} avec l'id {1} n'a pas été trouvé", _collectionName, id)));
            }
        }

        public async Task<T> Insert(T dao)
        {
            try
            {
                await Collection.InsertOneAsync(dao);
                return dao;
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

        public async Task<IList<T>> GetSeveral(IList<ObjectId> ids)
        {
            var result = new List<T>();

            foreach (var id in ids)
            {
                result.Add(await Get(id));
            }
            return result;
        }

        public async Task<List<T>> Get(Expression<Func<T, bool>> expression)
        {
            var documents = await Collection.FindAsync<T>(expression);
            return documents.ToList();
             
        }
    }
}
