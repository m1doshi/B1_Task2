using WebApplication1.Models;

namespace WebApplication1.Services.Interfaces
{
    public interface IClassService
    {
        Task<int> CreateClass(ClassModel model);
        Task<IEnumerable<ClassModel>> GetAllClasses();
    }
}