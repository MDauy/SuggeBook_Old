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
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;

        public InsertSuggestionCommandHandler(BaseRepository<SuggestionDao> repo, IBookService bookService
            , IAuthorService authorService)
        {
            _repo = repo;
            _bookService = bookService;
            _authorService = authorService;
        }

        public async Task<bool> ExecuteAsync(InsertSuggestionDto obj)
        {
            var dao = Framework.CustomAutoMapper.Map<SuggestionDto, SuggestionDao>(obj.Suggestion);
            dao.BookId = ObjectId.Parse(obj.BookId);            
            dao.UserId = ObjectId.Parse(obj.UserId);
            dao.CreationDate = DateTime.Today;
            dao.Categories = obj.Suggestion.Categories.Select(c => c.ToString()).ToList();
            await _repo.Insert(dao);

            var book = await _bookService.Get(obj.BookId);

            var authorId = obj.AuthorId;
            if (string.IsNullOrEmpty(authorId))
            {
                authorId = book.AuthorId;
            }
          
            return true;
        }

       
    }
}
