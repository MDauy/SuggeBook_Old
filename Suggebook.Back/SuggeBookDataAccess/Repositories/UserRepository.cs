using SuggeBookDAL.Dao;
using System.Threading.Tasks;
using MongoDB.Driver;
using System.Linq;
namespace SuggeBookDAL.Repositories
{
    public class UserRepository : BaseRepository<UserDao>, IUserRepository
    {
        public async Task<UserDao> GetFromUsername(string username)
        {
            var users = await Collection.FindAsync<UserDao>(u => u.UserName.ToLower() == username.ToLower());
            var usersList = users.ToList();
            if (usersList.Count > 1)
            {
                throw new System.Exception($"Several users wither username {username} have been found");
            }

            return usersList.FirstOrDefault();
        }
    }
}
