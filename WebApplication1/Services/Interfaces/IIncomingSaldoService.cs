using WebApplication1.Models;

namespace WebApplication1.Services.Interfaces
{
    public interface IIncomingSaldoService
    {
        Task<int> CreateIncomingSaldo(IncomingSaldoModel model);
        Task<IEnumerable<IncomingSaldoModel>> GetAllIncomingSaldos();
        Task<IncomingSaldoModel> GetLastIncomingSaldo();
    }
}