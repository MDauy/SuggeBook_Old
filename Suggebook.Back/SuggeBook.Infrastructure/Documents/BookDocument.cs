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
            PublishedDate = book.PublishedDate;

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

        [BsonElement("PublishedDate")]
        public string PublishedDate{ get; set; }

        public class BookAuthor : BaseDocument
        {
            public BookAuthor(Author author)
            {
                Id = new ObjectId(author.Id);
                Name = author.Name;
            }

            [BsonElement("Name")]
            public string Name{ get; set; }

        }

        public Book ToModel()
        {
            return new Book
            {
                Id = Id.ToString(),
                Author = new Author
                {
                    Id = Author.Id.ToString(),
                    Name = Author.Name,
                },
                Title = Title,
                Categories = Categories,
                PublishedDate =  PublishedDate
            };
        }
    }
}
