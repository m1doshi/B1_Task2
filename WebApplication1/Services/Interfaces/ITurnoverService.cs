using WebApplication1.Models;

namespace WebApplication1.Services.Interfaces
{
    public interface ITurnoverService
    {
        Task<int> CreateTurnover(TurnoverModel model);
        Task<IEnumerable<TurnoverModel>> GetAllTurnovers();
    }
}