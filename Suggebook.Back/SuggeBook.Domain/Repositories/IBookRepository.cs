using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SuggeBook.Domain.Model;

namespace SuggeBook.Domain.Repositories
{
    public interface IBookRepository
    {
        Task<Book> Get(string bookId);
        Task<List<Book>> GetFromAuthor(string authorId);
        Task<List<Book>> GetFromCategories(List<string> authorId);
        Task UpdateSuggestions(string bookId, string suggestionId);
        Task<Book> Create(Book book);
        Task<List<Book>> GetSimilar(Book book);
    }
}
