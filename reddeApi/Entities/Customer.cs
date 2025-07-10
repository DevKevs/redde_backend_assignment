using MongoDB.Bson.Serialization.Attributes;

namespace reddeApi.Entities
{
    public class Customer
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        [BsonElement("document"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Document { get; set; } = string.Empty;
        [BsonElement("name"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Name { get; set; } = string.Empty;
        [BsonElement("lastname"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string LastName { get; set; } = string.Empty;
        [BsonElement("email"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Email { get; set; } = string.Empty;
        [BsonElement("birth_date"), BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public DateTime DateOfBirth { get; set; } = DateTime.UtcNow;
        [BsonElement("created_at"), BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [BsonElement("updated_at"), BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
