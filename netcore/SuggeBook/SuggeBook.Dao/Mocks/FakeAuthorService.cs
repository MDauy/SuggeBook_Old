using System;
using System.Collections.Generic;
using System.Text;
using Bogus;
using SuggeBook.Dao.Models;

namespace SuggeBook.Dao.Mocks
{
    public class FakeAuthorService : IFakeAuthorService
    {
        public IFakeBooksService _booksService { get; set; }

        public FakeAuthorService (IFakeBooksService booksService)
        {
            _booksService = booksService;
        }


        public List<Author> Generate(int howMany)
        {
            var booksTest = new Faker<Author>().StrictMode(true)
                .RuleFor(a => a.FirstName, f => f.Name.FirstName())
                .RuleFor(a => a.LastName, f => f.Name.LastName())
                .RuleFor(a => a.Books, () => _booksService.Generate(7));

            var books = booksTest.Generate(howMany);

            return books;
        }
    }
}
