using System;
using System.Transactions;

namespace OutreachOperations.Api.Test.Infrastructure
{
    public class DatabaseFixtureBase : IDisposable
    {
        private readonly TransactionScope _transaction;
        
        public DatabaseFixtureBase()
        {
//            if (!DatabaseInit.DatabaseExists("BCAPIDatabase_Dev"))
//                DatabaseInit.CreateDatabase("BCAPIDatabase_Dev");

            _transaction = new TransactionScope(TransactionScopeOption.RequiresNew,
                new TransactionOptions {IsolationLevel = IsolationLevel.ReadUncommitted,Timeout = new TimeSpan(0,0,10)});
            
        }

        public void Dispose()
        {
            _transaction.Dispose();

        }
    }
}
