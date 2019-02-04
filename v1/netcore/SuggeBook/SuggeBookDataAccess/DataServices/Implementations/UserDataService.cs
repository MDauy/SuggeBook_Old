using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using SuggeBookDAL.Dao;
using SuggeBookDAL.DataServices.Contracts;

namespace SuggeBookDAL.DataServices.Implementations
{
    public class UserDataService : IUserDataService
	{
		private IMongoCollection<User> _usersCollection;
		private IMongoDatabase _db;

		public IMongoCollection<User> UsersCollection
		{
			get
			{
				if (_usersCollection == null)
				{
					_usersCollection = _db.GetCollection<User>("Users");
					if (_usersCollection == null)
					{
						_db.CreateCollection("Users");
					}
				}
				return _usersCollection;
			}
		}

        public UserDataService ()
        {
            _db = DataBaseAccess.Db;
        }

		public async Task<User> Create(User user)
		{
			await UsersCollection.InsertOneAsync(user);

			return user;
		}

		public async Task<User> GetUser(ObjectId id)
		{
			var t = await UsersCollection.FindAsync<User>(user => user.Id == id);
			return t.First();
		}

		public async Task<IEnumerable<User>> GetUsers(List<ObjectId> ids)
		{
			var users = await UsersCollection.FindAsync<User>(user => ids.Contains(user.Id));

			return users.ToList();
		}

		public async Task<bool> Remove(ObjectId id)
		{
           var result =  await UsersCollection.DeleteOneAsync(user => user.Id == id);

            if (result.DeletedCount == 1)
            {
                return true;
            }
            else
            {
                throw new Exception(string.Format("Update with user {0} went wrong : maybe not found or two many suggestions with same id", id));
            }
        }

		public async Task<bool> Update(ObjectId id, User user)
		{
			var result = await UsersCollection.ReplaceOneAsync<User> (b => b.Id == id, user);

            if (result.IsModifiedCountAvailable && result.ModifiedCount == 1)
            {
                return true;
            }
            else
            {
                throw new Exception(string.Format("Update with user {0} went wrong : maybe not found or two many suggestions with same id", id));
            }
        }
	}
}
