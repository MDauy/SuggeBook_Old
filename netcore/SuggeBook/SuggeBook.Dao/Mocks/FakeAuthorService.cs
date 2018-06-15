using System.Collections.Generic;
using AutoMapper;
using Bogus;
using SuggeBook.Dto.Models;

namespace SuggeBook.Dto.Mocks
{
	public class FakeAuthorService : IFakeAuthorService
	{
		public IFakeBooksService _booksService { get; set; }

		public FakeAuthorService(IFakeBooksService booksService)
		{
			_booksService = booksService;
		}


		public List<Author> Generate(int howMany)
		{
			var books = _booksService.Generate(7);
			var authorBooks = new List<Author.Book>();
			var config = new MapperConfiguration(cfg =>
		 {
			 cfg.CreateMap<Book, Author.Book>();
		 });
			var iMapper = config.CreateMapper();

			foreach (var book in books)
			{
				authorBooks.Add(iMapper.Map<Book, Author.Book>(book));
			}

			var bookstest = new Faker<Author>().StrictMode(true)
					.RuleFor(a => a.FirstName, f => f.Name.FirstName())
					.RuleFor(a => a.LastName, f => f.Name.LastName())
					.RuleFor(a => a.Books, f => authorBooks);

			var authors = bookstest.Generate(howMany);

			return authors;
		}
	}
}
