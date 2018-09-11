using SuggeBook.Dto.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuggeBook.Business.Services.Contracts
{
    public interface IBookService
    {
        Task Insert(BookDto book, string authorId);

        Task<BookDto> GetRandom();
    }
}
