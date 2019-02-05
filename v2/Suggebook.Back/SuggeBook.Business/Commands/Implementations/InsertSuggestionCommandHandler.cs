using MongoDB.Bson;
using SuggeBook.Business.Commands.Contracts;
using SuggeBook.Business.Services.Contracts;
using SuggeBook.Dto.Models;
using SuggeBookDAL.Dao;
using SuggeBookDAL.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SuggeBook.Business.Commands.Implementations
{
    public class InsertSuggestionCommandHandler : IInsertSuggestionCommandHandler
    {
        private readonly BaseRepository<SuggestionDao> _repo;

        public InsertSuggestionCommandHandler(BaseRepository<SuggestionDao> repo)
        {
            _repo = repo;
        }

        public async Task<SuggestionDao> ExecuteAsync(InsertSuggestionDto obj)
        {
            var dao = Framework.CustomAutoMapper.Map<SuggestionDto, SuggestionDao>(obj.Suggestion);
            dao.BookId = ObjectId.Parse(obj.BookId);
            dao.UserId = ObjectId.Parse(obj.UserId);
            dao.CreationDate = DateTime.Today;
            dao.Categories = obj.Suggestion.Categories.Select(c => c.ToString()).ToList();
            return await _repo.Insert(dao);
        }

       
    }
}
