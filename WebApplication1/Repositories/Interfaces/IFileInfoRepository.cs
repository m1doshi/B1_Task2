using WebApplication1.Entities;

namespace WebApplication1.Repositories.Interfaces
{
    public interface IFileInfoRepository
    {
        Task<int> CreateFileInfo(FileInfoEntity entity);
        Task<IEnumerable<FileInfoEntity>> GetAllFileInfos();
        Task<FileInfoEntity> GetFileInfoByName(string name);
    }
}