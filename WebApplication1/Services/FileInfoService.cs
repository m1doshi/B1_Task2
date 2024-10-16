using WebApplication1.Entities;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services
{
    public class FileInfoService : IFileInfoService
    {
        private readonly IFileInfoRepository repository;
        public FileInfoService(IFileInfoRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<FileInfoModel>> GetAllFileInfos()
        {
            var list = await repository.GetAllFileInfos();
            return list.Select(f => new FileInfoModel
            {
                Id = f.Id,
                FileName = f.FileName
            });
        }
        public async Task<int> CreateFileInfo(FileInfoModel model)
        {
            var entity = new FileInfoEntity
            {
                Id = model.Id,
                FileName = model.FileName
            };
            return await repository.CreateFileInfo(entity);
        }
        public async Task<FileInfoModel> GetFileInfoByName(string name)
        {
            var entity = await repository.GetFileInfoByName(name);
            return new FileInfoModel
            {
                Id = entity.Id,
                FileName = entity.FileName
            };
        }
    }
}
