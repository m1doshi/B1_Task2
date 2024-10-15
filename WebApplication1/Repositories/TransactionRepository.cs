using Microsoft.EntityFrameworkCore;
using WebApplication1.Database;
using WebApplication1.Entities;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories
{
    public class TransactionRepository:ITransactionRepository
    {
        private readonly MyDbContext context;
        public TransactionRepository(MyDbContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateTransaction(TransactionEntity entity)
        {
            await context.Transactions.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<IEnumerable<TransactionEntity>> GetAllTransactions()
        {
            return await context.Transactions.ToListAsync();
        }
    }
}
