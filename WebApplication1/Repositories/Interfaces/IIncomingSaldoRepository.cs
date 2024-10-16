using WebApplication1.Entities;

namespace WebApplication1.Repositories.Interfaces
{
    public interface IIncomingSaldoRepository
    {
        Task<int> CreateIncomingSaldo(IncomingSaldoEntity entity);
        Task<IEnumerable<IncomingSaldoEntity>> GetAllIncomingSaldos();
        Task<IncomingSaldoEntity> GetLastIncomingSaldo();
    }
}