using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace P2P.Models.Entities
{
    public class Transaction
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("lenderId")]
        public string LenderId { get; set; }
        [BsonElement("borrowerId")]
        public string BorrowerId { get; set; }
        [BsonElement("amount")]
        public decimal Amount { get; set; }
        [BsonElement("transactionDate")]
        public DateTime TransactionDate { get; set; } = DateTime.Now;
    }
}

