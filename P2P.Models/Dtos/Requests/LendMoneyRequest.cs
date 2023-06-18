using System;
namespace P2P.Models.Dtos.Requests
{
    public class LendMoneyRequest
    {
        public string ReceieverFullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Amount { get; set; }
    }
}

