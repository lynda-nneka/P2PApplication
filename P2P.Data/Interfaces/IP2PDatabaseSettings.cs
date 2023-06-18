using System;
namespace P2P.Data.Interfaces
{
    public interface IP2PDatabaseSettings
    {
        string LoanRequestCollectionName { get; set; }
        string TransactionCollectionName { get; set; }
        string UserCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

    }
}

