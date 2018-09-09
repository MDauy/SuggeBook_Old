﻿using System.Threading.Tasks;
using SuggeBook.Business.Commands.Contracts;
using SuggeBook.Dto.Models;
using SuggeBookDAL.Dao;
using SuggeBookDAL.Repositories;

namespace SuggeBook.Business.Commands.Implementations
{
    public class InsertBookCommandHandler : IInsertBookCommandHandler
    {
        private BaseRepository<BookDao>  _repo;

        public InsertBookCommandHandler (BaseRepository<BookDao> repo)
        {
            _repo = repo;
        }

        public async Task<bool> ExecuteAsync(InsertBookCommandRequest command)
        {
           var bookDao = Framework.CustomAutoMapper.Map<BookDto, BookDao> (command.BookDto);
            bookDao.AuthorId = new MongoDB.Bson.ObjectId(command.AuthorId);
            await _repo.Insert(bookDao);
            return true;
        }
    }
}
