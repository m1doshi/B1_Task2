using Microsoft.EntityFrameworkCore;
using WebApplication1.Database;
using WebApplication1.Entities;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories
{
    public class IncomingSaldoRepository : IIncomingSaldoRepository
    {
        private readonly MyDbContext context;
        public IncomingSaldoRepository(MyDbContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateIncomingSaldo(IncomingSaldoEntity entity)
        {
            await context.IncomingSaldos.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<IEnumerable<IncomingSaldoEntity>> GetAllIncomingSaldos()
        {
            return await context.IncomingSaldos.ToListAsync();
        }
    }
}
