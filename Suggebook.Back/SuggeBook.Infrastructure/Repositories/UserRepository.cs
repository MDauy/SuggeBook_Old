using System.Linq;
using System.Threading.Tasks;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.Repositories;
using SuggeBook.Infrastructure.Documents;
using SuggeBook.Infrastructure.Exceptions;
using SuggeBook.Framework;
using MongoDB.Bson;
using System.Linq.Expressions;
using System;
using AutoMapper;

namespace SuggeBook.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;

        public UserRepository(IBaseRepository<UserDocument> baseRepo,
        IMapper mapper)
        {
            _baseRepository = baseRepo;
            _mapper = mapper;
        }

        private readonly IBaseRepository<UserDocument> _baseRepository;

        public async Task<User> Create(User user)
        {
            var userDocument = await _baseRepository.Insert(_mapper.Map<UserDocument>(user));
            return _mapper.Map<User>(userDocument);
        }

        private async Task<User> BasicGetUser(Expression<Func<UserDocument, bool>> func, string userIdentifier)
        {
            var users = await _baseRepository.Get(func);
            if (users.Count > 1)
            {
                throw new ObjectNotUniqueException("User", userIdentifier);
            }

            return _mapper.Map<User>(users.First());
        }

        public async Task<User> GetFromUsername(string username)
        {
            return await BasicGetUser(x => x.UserName == username, username);
        }

        public async Task<User> Get(string userId)
        {
            return await BasicGetUser(x => x.Oid == ObjectId.Parse(userId), userId);
        }

        public async Task<User> GetSimilarUsername(string username)
        {
            var existingUser =
                await _baseRepository.Get(u => string.Equals(u.UserName, username));

            if (existingUser.IsNullOrEmpty())
            {
                return null;
            }

            if (existingUser.Count > 1)
            {
                throw new ObjectNotUniqueException("User", $"{username}");
            }

            return _mapper.Map<User>(existingUser.First());
        }

        public async Task<User> GetSimilarMail(string mail)
        {
            var existingUser =
                await _baseRepository.Get(u => string.Equals(u.Email, mail));

            if (existingUser.IsNullOrEmpty())
            {
                return null;
            }

            if (existingUser.Count > 1)
            {
                throw new ObjectNotUniqueException("User", $"{mail}");
            }

            return _mapper.Map<User>(existingUser.First());
        }

        public async Task<User> Connect(string usernameOrEmail, string password)
        {
            var users = await _baseRepository.Get(u => u.UserName == usernameOrEmail);
            if (users.IsNullOrEmpty())
            {
                users = await _baseRepository.Get(u => u.Email == usernameOrEmail);
            }

            if (!users.IsNullOrEmpty())
            {
                if (users.Count > 1)
                {
                    throw new ObjectNotUniqueException("User", usernameOrEmail);
                }

                var user = users.First();

                if (string.Equals(user.Password, password))
                {

                    return _mapper.Map<UserDocument, User>(user);
                }
            }

            return null;
        }
    }
}
