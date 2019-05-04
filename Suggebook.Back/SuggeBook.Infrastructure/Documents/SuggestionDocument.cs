﻿using MongoDB.Bson;
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

        public SuggestionDocument(Suggestion suggestion)
        {
            Title = suggestion.Title;
            Categories = suggestion.Categories;
            CreationDate = suggestion.CreationDate;
            Content = suggestion.Content;
            BookId = new ObjectId(suggestion.Book.Id);
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
    }
}