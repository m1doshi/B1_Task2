using Microsoft.EntityFrameworkCore;
using WebApplication1.Database;
using WebApplication1.Entities;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MyDbContext context;
        public AccountRepository(MyDbContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateAccount(AccountEntity entity)
        {
            await context.Accounts.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<IEnumerable<AccountEntity>> GetAllAccounts()
        {
            return await context.Accounts.ToListAsync();
        }
    }
}
