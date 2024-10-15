using WebApplication1.Models;

namespace WebApplication1.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<int> CreateTransaction(TransactionModel model);
        Task<IEnumerable<TransactionModel>> GetAllTransactions();
    }
}