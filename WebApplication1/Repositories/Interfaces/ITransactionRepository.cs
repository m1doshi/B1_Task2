using WebApplication1.Entities;

namespace WebApplication1.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Task<int> CreateTransaction(TransactionEntity entity);
        Task<IEnumerable<TransactionEntity>> GetAllTransactions();
    }
}
