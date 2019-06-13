using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using MongoDB.Bson;
using SuggeBook.Domain.Model;
using SuggeBook.Framework;

namespace SuggeBook.Infrastructure.Documents
{
	public class BookDocument : BaseDocument
	{
        public BookDocument() { }

        public BookDocument(Book book)
        {
            Author = new BookAuthor(book.Author);
            Categories = book.Categories;
            Isbn10 = book.Isbn10;
            Isbn13= book.Isbn13;
            Title = book.Title;
            
        }

		[BsonElement("Title")]
		public string Title { get; set; }

		[BsonElement("ISBN10")]
		public string Isbn10 { get; set; }

        [BsonElement("ISBN13")]
        public string Isbn13 { get; set; }

        [BsonElement("Categories")]
        public IList<string> Categories { get; set; }
        
        [BsonElement("Author")]
        public BookAuthor Author { get; set; }

        [BsonElement("NbSuggestions")]
        public int NbSuggestions { get; set; }

        public class BookAuthor : BaseDocument
        {
            public BookAuthor(Author author)
            {
                Id = new ObjectId(author.Id);
                Firstname = author.Firstname;
                Lastname = author.Lastname;
            }

            [BsonElement("Firstname")]
            public string Firstname{ get; set; }

            [BsonElement("Lastname")]
            public string Lastname { get; set; }
        }

        public Book ToModel()
        {
            return new Book
            {
                Id = Id.ToString(),
                Author = new Author
                {
                    Id = Author.Id.ToString(),
                    Firstname = Author.Firstname,
                    Lastname = Author.Lastname
                },
                Title = Title,
                Categories = Categories
            };
        }
    }
}
