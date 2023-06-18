using System;
using P2P.Data.Interfaces;

namespace P2P.Data.Implementations
{
    public class P2PDatabaseSettings : IP2PDatabaseSettings
    {
        public string LoanRequestCollectionName { get; set; }
        public string TransactionCollectionName { get; set; }
        public string UserCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public  string DatabaseName { get; set; }
    }
}

