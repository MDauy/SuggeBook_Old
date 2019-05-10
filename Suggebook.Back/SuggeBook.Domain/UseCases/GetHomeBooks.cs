using SuggeBook.Domain.Model;
using SuggeBook.Domain.Repositories;
using SuggeBook.Domain.UseCasesInterfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuggeBook.Domain.UseCases
{
    public class GetHomeBooks : IGetHomeBooks
    {
        private readonly IBookRepository _bookRepository;

        public GetHomeBooks(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IList<Book>> Get()
        {
            return await _bookRepository.GetHomeBooks();
        }
    }
}
