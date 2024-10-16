using Microsoft.EntityFrameworkCore;
using WebApplication1.Database;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class DataService
    {
        private readonly DataRepository repository;

        public DataService(DataRepository repository)
        {
            this.repository = repository;
        }
        public IEnumerable<AccountDataViewModel> GetDataByFileId(int fileId)
        {
            return repository.GetDataByFileId(fileId);
        }
    }
}
