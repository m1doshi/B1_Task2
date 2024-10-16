using Microsoft.EntityFrameworkCore;
using WebApplication1.Database;
using WebApplication1.Entities;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories
{
    public class OutgoingSaldoRepository : IOutgoingSaldoRepository
    {
        private readonly MyDbContext context;
        public OutgoingSaldoRepository(MyDbContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateOutgoingSaldo(OutgoingSaldoEntity entity)
        {
            await context.OutgoingSaldos.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<IEnumerable<OutgoingSaldoEntity>> GetAllOutgoingSaldos()
        {
            return await context.OutgoingSaldos.ToListAsync();
        }
    }
}
