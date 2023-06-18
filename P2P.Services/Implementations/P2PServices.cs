using System;
using P2P.Data.Interfaces;
using P2P.Models.Dtos.Requests;
using P2P.Services.Interfaces;
using MongoDB.Driver;
using P2P.Models.Entities;
using MongoDB.Bson;

namespace P2P.Services.Implementations
{
    public class P2PServices  : IP2PServices
    {
        private readonly IMongoCollection<LoanRequest> _loanRequest;
        private readonly IMongoCollection<User> _user;
        private readonly IMongoCollection<Transaction> _transaction;
        public P2PServices(IP2PDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _loanRequest = database.GetCollection<LoanRequest>(settings.LoanRequestCollectionName);
            _user = database.GetCollection<User>(settings.UserCollectionName);
            _transaction = database.GetCollection<Transaction>(settings.TransactionCollectionName);
        }

        public LoanRequest CreateLoanRequest(string lenderId, string borrowerId, decimal amount )
        {
            var lender = _user.Find(u => u.Id == lenderId).FirstOrDefault();

            if (lender == null)
            {
                throw new InvalidOperationException(message: $"Lender with ID: {lenderId} not found");
            }

            var loanRequest = new LoanRequest
            {
                LenderId = lenderId,
                BorrowerId = borrowerId,
                Amount = amount,
                RequestDate = DateTime.UtcNow
            };
            _loanRequest.InsertOne(loanRequest);
            return loanRequest;
        }

        public User CreateUser(User user)
        {
            _user.InsertOne(user);
            return user;
        }

        public User DeleteUser(string Id)
        {

            var user = _user.Find(user => user.Id == Id).FirstOrDefault();

            if (user == null)
            {
                return null;
            }
            _user.DeleteOne(user => user.Id == Id);

            return user;
        }

        public User GetUser(string Id)
        {
            var user =  _user.Find(user => user.Id == Id).FirstOrDefault();

            if (user == null)
            {
                return null;
            }

            return user;
        }

        public Transaction CreateTransaction(string loanRequestId, decimal amount)
        {
            var loanRequestFilter = Builders<LoanRequest>.Filter.Eq(lr => lr.Id, loanRequestId);
            var loanRequest = _loanRequest.Find(loanRequestFilter).FirstOrDefault();

            if (loanRequest == null)
            {
                
                throw new InvalidOperationException(message: "can't proceed with this transaction, confirm the loan request");
            }

            var transaction = new Transaction
            {
                LenderId = loanRequest.LenderId,
                BorrowerId = loanRequest.BorrowerId,
                Amount = amount,
                TransactionDate = DateTime.UtcNow
                
            };

            _transaction.InsertOne(transaction);
            return transaction;
        }

        public User UpdateUser(string Id, User user)
        {

            var existingUser = _user.Find(user => user.Id == Id).FirstOrDefault();

            if (existingUser == null)
            {
                return null;
            }

            _user.ReplaceOne(user => user.Id == Id, user);
    
            return user;
        }
    }
}

