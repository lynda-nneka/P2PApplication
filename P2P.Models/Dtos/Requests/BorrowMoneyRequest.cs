using System;
namespace P2P.Models.Dtos.Requests
{
    public class BorrowMoneyRequest
    {
        public string IssuerFullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Amount { get; set; }
    }
}

