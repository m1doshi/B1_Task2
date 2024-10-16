using WebApplication1.Entities;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository repository;
        public ClassService(IClassRepository repository)
        {
            this.repository = repository;
        }
        public async Task<int> CreateClass(ClassModel model)
        {
            var entity = new ClassEntity
            {
                Id = model.Id,
                Name = model.Name
            };
            await repository.CreateClass(entity);
            return model.Id;
        }

        public async Task<IEnumerable<ClassModel>> GetAllClasses()
        {
            var list = await repository.GetAllClasses();
            return list.Select(c => new ClassModel
            {
                Id = c.Id,
                Name = c.Name
            });
        }

        public async Task<ClassModel> GetClassById(int id)
        {
            var entity = await repository.GetClassById(id);
            if (entity == null) return null;
            return new ClassModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
        public async Task<ClassModel> GetClassByName(string name)
        {
            var entity = await repository.GetClassByName(name);
            if (entity == null) return null;
            return new ClassModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
        public async Task<ClassModel> GetLastClass()
        {
            var entity = await repository.GetLastClass();
            return new ClassModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
