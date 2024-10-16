using Microsoft.EntityFrameworkCore;
using WebApplication1.Database;
using WebApplication1.Entities;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories
{
    public class NewAccountRepository : INewAccountRepository
    {
        private readonly MyDbContext context;
        public NewAccountRepository(MyDbContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateAccount(NewAccountEntity entity)
        {
            await context.Accounts.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }
        public async Task<IEnumerable<NewAccountEntity>> GetAccountsByFileId(int id)
        {
            return await context.Accounts.Where(a => a.FileId == id).ToListAsync();
        }

        public async Task<IEnumerable<NewAccountEntity>> GetAllAccounts()
        {
            return await context.Accounts.ToListAsync();
        }
    }
}
