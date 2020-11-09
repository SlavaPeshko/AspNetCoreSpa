using System.Transactions;

namespace AspNetCoreSpa.Application.Helpers
{
    public static class Transaction
    {
        public static TransactionScope CreateAsyncTransactionScope(
            IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            var transactionOptions = new TransactionOptions
            {
                IsolationLevel = isolationLevel,
                Timeout = TransactionManager.MaximumTimeout
            };

            return new TransactionScope(TransactionScopeOption.Required, transactionOptions,
                TransactionScopeAsyncFlowOption.Enabled);
        }
    }
}