using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace P2P.Models.Entities
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("address")]
        public string Address { get; set; }
        [BsonElement("phonenumber")]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        [BsonElement("email")]
        public string Email { get; set; }
        [BsonElement("createdat")]
        public DateTime CreatedAt { get; set; }
        [BsonElement("updatedat")]
        public DateTime UpdatedAt { get; set; }
    }
}

