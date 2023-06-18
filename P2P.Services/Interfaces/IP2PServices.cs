using System;
using P2P.Models.Dtos.Requests;
using P2P.Models.Entities;

namespace P2P.Services.Interfaces
{
    public interface IP2PServices
    {
        User CreateUser(User user);
        User GetUser(string Id);
        Transaction CreateTransaction(string loanRequestId, decimal amount);
        LoanRequest CreateLoanRequest(string LenderId, string borrowerId, decimal amount);
        User UpdateUser(string Id, User user);
        User DeleteUser(string Id);
    }
}

