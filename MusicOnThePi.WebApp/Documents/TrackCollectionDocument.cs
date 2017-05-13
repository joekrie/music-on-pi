using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace MusicOnThePi.WebApp.Documents
{
    public class TrackCollectionDocument
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("artist")]
        public string Artist { get; set; }
        [BsonElement("category")]
        public string Category { get; set; }
        [BsonElement("tags")]
        public List<string> Tags { get; set; } = new List<string>();  
    }
}
