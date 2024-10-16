using WebApplication1.Models;

namespace WebApplication1.Services.Interfaces
{
    public interface IFileInfoService
    {
        Task<int> CreateFileInfo(FileInfoModel model);
        Task<IEnumerable<FileInfoModel>> GetAllFileInfos();
        Task<FileInfoModel> GetFileInfoByName(string name);
    }
}