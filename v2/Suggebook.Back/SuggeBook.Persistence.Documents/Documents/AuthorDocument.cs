using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace SuggeBookDAL.Persistence.Documents
{
    public class AuthorDocument : BaseDocument
    {
        [BsonElement("Firstname")]
        public string Firstname { get; set; }

        [BsonElement("Lastname")]
        public string Lastname { get; set; }

        [BsonElement("NbSuggestions")]
        public int NbSuggestions { get; set; }


    }

}
