using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MusicOnThePi.WebApp.Documents
{
    public class TrackDocument
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("file_path")]
        public string FilePath { get; set; }
        [BsonElement("mime_type")]
        public string MimeType { get; set; }
    }
}
