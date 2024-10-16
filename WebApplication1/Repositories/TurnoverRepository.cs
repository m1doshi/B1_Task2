using Microsoft.EntityFrameworkCore;
using WebApplication1.Database;
using WebApplication1.Entities;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories
{
    public class TurnoverRepository : ITurnoverRepository
    {
        private readonly MyDbContext context;
        public TurnoverRepository(MyDbContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateTurnover(TurnoverEntity entity)
        {
            await context.Turnovers.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<IEnumerable<TurnoverEntity>> GetAllTurnovers()
        {
            return await context.Turnovers.ToListAsync();
        }
    }
}
