using WebApplication1.Entities;

namespace WebApplication1.Repositories.Interfaces
{
    public interface ITurnoverRepository
    {
        Task<int> CreateTurnover(TurnoverEntity entity);
        Task<IEnumerable<TurnoverEntity>> GetAllTurnovers();
    }
}