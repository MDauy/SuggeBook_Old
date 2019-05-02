using SuggeBook.Domain.Model;
using SuggeBook.Domain.UseCasesInterfaces;
using System;
using System.Threading.Tasks;

namespace SuggeBook.Domain.UseCases
{
    public class CreateBook : ICreateBook
    {
        public Task<Book> Create(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
