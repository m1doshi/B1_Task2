using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Repositories.Interfaces
{
    public interface IClassRepository
    {
        Task<int> CreateClass(ClassEntity entity);
        Task<IEnumerable<ClassEntity>> GetAllClasses();
        Task<ClassEntity> GetClassById(int id);
        Task<ClassEntity> GetLastClass();
    }
}
