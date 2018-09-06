using SuggeBook.Business.Commands.Contracts;
using SuggeBook.Business.Services.Contracts;
using SuggeBook.Dto.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuggeBook.Business.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IInsertBookCommandHandler _insertBookCommandHandler;

        public BookService(IInsertBookCommandHandler insertBookCommandHandler)
        {
            _insertBookCommandHandler = insertBookCommandHandler;
        }

        public async Task Insert(BookDto book, string authorId)
        {
            await _insertBookCommandHandler.ExecuteAsync(new InsertBookCommandRequest { BookDto = book, AuthorId = authorId });
        }
    }
}
