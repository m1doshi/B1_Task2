using WebApplication1.Entities;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services
{
    public class OutgoingSaldoService : IOutgoingSaldoService
    {
        private readonly IOutgoingSaldoRepository repository;
        public OutgoingSaldoService(IOutgoingSaldoRepository repository)
        {
            this.repository = repository;
        }
        public async Task<int> CreateOutgoingSaldo(OutgoingSaldoModel model)
        {
            var entity = new OutgoingSaldoEntity
            {
                Id = model.Id,
                Active = model.Active,
                Passive = model.Passive,
                IncomingSaldoId = model.IncomingSaldoId,
                TurnoverId = model.TurnoverId,
            };
            await repository.CreateOutgoingSaldo(entity);
            return model.Id;
        }

        public async Task<IEnumerable<OutgoingSaldoModel>> GetAllOutgoingSaldos()
        {
            var list = await repository.GetAllOutgoingSaldos();
            return list.Select(s => new OutgoingSaldoModel
            {
                Id = s.Id,
                Active = s.Active,
                Passive = s.Passive,
                IncomingSaldoId = s.IncomingSaldoId,
                TurnoverId = s.TurnoverId,
            });
        }
    }
}
