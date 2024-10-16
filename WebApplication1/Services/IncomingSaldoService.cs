using WebApplication1.Entities;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services
{
    public class IncomingSaldoService : IIncomingSaldoService
    {
        private readonly IIncomingSaldoRepository repository;
        public IncomingSaldoService(IIncomingSaldoRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> CreateIncomingSaldo(IncomingSaldoModel model)
        {
            var entity = new IncomingSaldoEntity
            {
                Id = model.Id,
                Active = model.Active,
                Passive = model.Passive,
                AccountId = model.AccountId
            };
            await repository.CreateIncomingSaldo(entity);
            return model.Id;
        }

        public async Task<IEnumerable<IncomingSaldoModel>> GetAllIncomingSaldos()
        {
            var list = await repository.GetAllIncomingSaldos();
            return list.Select(s => new IncomingSaldoModel
            {
                Id = s.Id,
                Active = s.Active,
                Passive = s.Passive,
                AccountId = s.AccountId
            });
        }
    }
}
