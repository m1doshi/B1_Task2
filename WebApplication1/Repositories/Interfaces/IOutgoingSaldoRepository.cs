using WebApplication1.Entities;

namespace WebApplication1.Repositories.Interfaces
{
    public interface IOutgoingSaldoRepository
    {
        Task<int> CreateOutgoingSaldo(OutgoingSaldoEntity entity);
        Task<IEnumerable<OutgoingSaldoEntity>> GetAllOutgoingSaldos();
    }
}