using System.Transactions;
using WebApplication1.Entities;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository repository;
        public TransactionService(ITransactionRepository repository)
        {
            this.repository = repository;
        }
        public async Task<int> CreateTransaction(TransactionModel model)
        {
            var entity = new TransactionEntity
            {
                Id = model.Id,
                AccountId = model.AccountId,
                Debit = model.Debit,
                Credit = model.Credit,
                OutgoingSaldoActive = model.OutgoingSaldoActive,
                OutgoingSaldoPassive = model.OutgoingSaldoPassive
            };
            await repository.CreateTransaction(entity);
            return model.Id;
        }
        public async Task<IEnumerable<TransactionModel>> GetAllTransactions()
        {
            var list = await repository.GetAllTransactions();
            return list.Select(a => new TransactionModel
            {
                Id = a.Id,
                AccountId = a.AccountId,
                Debit = a.Debit,
                Credit = a.Credit,
                OutgoingSaldoActive = a.OutgoingSaldoActive,
                OutgoingSaldoPassive = a.OutgoingSaldoPassive
            });
        }
    }
}
