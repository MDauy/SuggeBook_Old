
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using SuggeBook.Framework;
using SuggeBook.Infrastructure.Documents;

namespace SuggeBook.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseDocument, new()
    {
        private IMongoCollection<T> _collection;
        protected IMongoDatabase Db;
        protected string CollectionName;

        public string GetCollectionName(BaseDocument document)
        {
            switch (document)
            {
                case SuggestionDocument _:
                    return "Suggestions";
                case AuthorDocument _:
                    return "Authors";
                case UserDocument _:
                    return "Users";
                case SagaDocument _:
                    return "Sagas";
                    case MissedAuthorDocument _:
                    return "MissedAuthors";
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
                    _collection = Db.GetCollection<T>(CollectionName);
                    if (_collection == null)
                    {
                        Db.CreateCollection(CollectionName);
                    }
                }
                return _collection;

            }
        }

        public BaseRepository()
        {
            Db = DataBaseAccess.Db;
            CollectionName = GetCollectionName(new T());
        }

        public async Task<T> Get(string id)
        {
            try
            {
                var objectId = new ObjectId(id);
                var document = await Collection.FindAsync(d => d.Id == objectId);
                return document.FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, new Exception (
                    $"L'objet dans la collection {CollectionName} avec l'id {id} n'a pas été trouvé"));
            }
        }

        public async Task<T> Insert(T document)
        {
            await Collection.InsertOneAsync(document);
            return document;
        }

        public async Task<bool> Delete(T document)
        {
            var result = await Collection.DeleteOneAsync(s => s.Id == document.Id);

            if (result.DeletedCount == 1)
            {
                return true;
            }
            else
            {
                throw new Exception(
                    $"Deletion with {document.GetType()} {document.Id} went wrong : maybe not found or two many suggestions with same id");
            }
        }

        public async Task<bool> Update(T document)
        {
            var result = await Collection.ReplaceOneAsync(s => s.Id == document.Id, document);

            if (result.IsModifiedCountAvailable && result.ModifiedCount == 1)
            {
                return true;
            }
            else
            {
                throw new Exception(
                    $"Update with {document.GetType()} {document.Id} went wrong : maybe not found or two many suggestions with same id");
            }
        }

        public async Task<IList<T>> GetSeveral(IList<string> ids)
        {
            var result = new List<T>();

            foreach (var id in ids)
            {
                result.Add(await Get(id));
            }
            return result;
        }

        public async Task<IList<T>> Get(Expression<Func<T, bool>> expression)
        {
            var documents = await Collection.FindAsync<T>(expression);
            return documents.ToList();
             
        }
    }
}
