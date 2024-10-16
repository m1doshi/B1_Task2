using WebApplication1.Entities;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services
{
    public class TurnoverService : ITurnoverService
    {
        private readonly ITurnoverRepository repository;
        public TurnoverService(ITurnoverRepository repository)
        {
            this.repository = repository;
        }
        public async Task<int> CreateTurnover(TurnoverModel model)
        {
            var entity = new TurnoverEntity
            {
                Id = model.Id,
                Debit = model.Debit,
                Credit = model.Credit,
                AccountId = model.AccountId
            };
            await repository.CreateTurnover(entity);
            return model.Id;
        }

        public async Task<IEnumerable<TurnoverModel>> GetAllTurnovers()
        {
            var list = await repository.GetAllTurnovers();
            return list.Select(t => new TurnoverModel
            {
                Id = t.Id,
                Debit = t.Debit,
                Credit = t.Credit,
                AccountId = t.AccountId
            });
        }
    }
}
