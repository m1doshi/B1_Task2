using WebApplication1.Models;

namespace WebApplication1.Services.Interfaces
{
    public interface IOutgoingSaldoService
    {
        Task<int> CreateOutgoingSaldo(OutgoingSaldoModel model);
        Task<IEnumerable<OutgoingSaldoModel>> GetAllOutgoingSaldos();
    }
}