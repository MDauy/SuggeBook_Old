using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using SuggeBook.Domain.Model;

namespace SuggeBook.Infrastructure.Documents
{
    public class SuggestionDocument : BaseDocument
    {
        public SuggestionDocument()
        {
        }

        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("BookId")]
        public ObjectId BookId { get; set; }

        [BsonElement("Content")]
        public string Content { get; set; }

        [BsonElement("Categories")]
        public IList<string> Categories { get; set; }

        [BsonElement("Creation_Date")]
        public DateTime? CreationDate { get; set; }

        [BsonElement("User_Id")]
        public ObjectId UserId { get; set; }

        public Suggestion ToModel()
        {
            return new Suggestion
            {
                Id = Id.ToString(),
                Book = new Book()
                {
                    Id = BookId.ToString()
                },
                User = new User()
                {
                    Id = UserId.ToString()
                },
                Title = Title,
                Content = Content,
                CreationDate = CreationDate
            };
        }
    }
}
