using Microsoft.EntityFrameworkCore;
using WebApplication1.Database;
using WebApplication1.Entities;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories
{
    public class FileInfoRepository : IFileInfoRepository
    {
        private readonly MyDbContext context;
        public FileInfoRepository(MyDbContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateFileInfo(FileInfoEntity entity)
        {
            await context.FileInfos.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<FileInfoEntity> GetFileInfoByName(string name)
        {
            return await context.FileInfos.Where(f => f.FileName == name).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<FileInfoEntity>> GetAllFileInfos()
        {
            return await context.FileInfos.ToListAsync();
        }
    }
}
