using WebApplication1.Entities;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository repository;
        public AccountService(IAccountRepository repository)
        {
            this.repository = repository;
        }
        public async Task<int> CreateAccount(AccountModel model)
        {
            var entity = new AccountEntity
            {
                Id = model.Id,
                IncomingSaldoActive = model.IncomingSaldoActive,
                IncomingSaldoPassive = model.IncomingSaldoPassive,
                ClassId = model.ClassId
            };
            await repository.CreateAccount(entity);
            return model.Id;
        }
        public async Task<IEnumerable<AccountModel>> GetAllAccounts()
        {
            var list = await repository.GetAllAccounts();
            return list.Select(a => new AccountModel
            {
                Id = a.Id,
                IncomingSaldoActive = a.IncomingSaldoActive,
                IncomingSaldoPassive = a.IncomingSaldoPassive,
                ClassId = a.ClassId
            });
        }
    }
}
