using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using SuggeBookDataAccess.Dao;

namespace SuggeBookDataAccess.DataServices
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

		public async Task Remove(ObjectId id)
		{
            await UsersCollection.DeleteOneAsync(user => user.Id == id);
		}

		public async Task Update(ObjectId id, User user)
		{
			await UsersCollection.ReplaceOneAsync<User> (b => b.Id == id, user);
		}
	}
}
