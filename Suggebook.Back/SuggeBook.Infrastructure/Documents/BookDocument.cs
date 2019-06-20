using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using MongoDB.Bson;
using SuggeBook.Domain.Model;
using SuggeBook.Framework;
using System.Linq;

namespace SuggeBook.Infrastructure.Documents
{
    public class BookDocument : BaseDocument
    {
        public BookDocument() { }

        public BookDocument(Book book)
        {
             Authors = book.Authors.ToList().ConvertAll(b => 
             {
                 return new BookAuthor(b);
             });
            Categories = book.Categories;
            Isbn10 = book.Isbn10;
            Isbn13 = book.Isbn13;
            Title = book.Title;
            PublishedDate = book.PublishedDate;
            Saga = new SagaDocument(book.Saga);
            SagaPosition = book.SagaPosition;
        }

        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("ISBN10")]
        public string Isbn10 { get; set; }

        [BsonElement("ISBN13")]
        public string Isbn13 { get; set; }

        [BsonElement("Categories")]
        public IList<string> Categories { get; set; }

        [BsonElement("Authors")]
        public IList<BookAuthor> Authors { get; set; }

        [BsonElement("NbSuggestions")]
        public int NbSuggestions { get; set; }

        [BsonElement("PublishedDate")]
        public string PublishedDate { get; set; }

        [BsonElement("Saga")]
        public SagaDocument Saga { get; set; }

        [BsonElement("SagaPosition")]
        public double? SagaPosition { get; set; }

        public class BookAuthor : BaseDocument
        {
            public BookAuthor(Author author)
            {
                Id = new ObjectId(author.Id);
                Name = author.Name;
            }

            [BsonElement("Name")]
            public string Name { get; set; }

        }

        public Book ToModel()
        {
            var book = new Book
            {
                Id = Id.ToString(),
                Authors = new List<Author>(),
                Title = Title,
                Categories = Categories,
                PublishedDate = PublishedDate,
                Saga = Saga.ToModel(),
                SagaPosition = SagaPosition
            };
            book.Authors = Authors.ToList().ConvertAll(author =>
            {
                return new Author
                {
                    Name = author.Name,
                    Id = author.Id.ToString()
                };
            });
            return book;
        }
    }
}
