using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace P2P.Models.Entities
{
    public class LoanRequest
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("borrowerId")]
        public string BorrowerId { get; set; }
        [BsonElement("lenderId")]
        public string LenderId { get; set; }
        [BsonElement("amount")]
        public decimal Amount { get; set; }
        [BsonElement("requestDate")]
        public DateTime RequestDate { get; set; } = DateTime.Now;
        [BsonElement("isApproved")]
        public bool IsApproved { get; set; } = false;
    }
}

