using Microsoft.EntityFrameworkCore;
using WebApplication1.Database;
using WebApplication1.Entities;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly MyDbContext context;
        public ClassRepository(MyDbContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateClass(ClassEntity entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<IEnumerable<ClassEntity>> GetAllClasses()
        {
            return await context.Classes.ToListAsync();
        }
    }
}
