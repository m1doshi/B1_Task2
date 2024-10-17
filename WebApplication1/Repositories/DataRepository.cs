using Microsoft.EntityFrameworkCore;
using WebApplication1.Database;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class DataRepository //Репозиторий для подтягивания всех связанных данных по конкретному файлу из БД 
    {
        private readonly MyDbContext context;

        public DataRepository(MyDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<AccountDataViewModel> GetDataByFileId(int fileId)
        {

            var accounts = context.Accounts     //Сначала подтягивается счёт с навигационным св-вом
                .Include(a => a.Class)
                .ToList();

            var accountData = accounts.Select(account => new AccountDataViewModel   //Далее за счётом подтягиваются все остальные данные
            {
                AccountId = account.Id,
                ClassName = account.Class.Name,
                IncomingSaldo = context.IncomingSaldos
                    .FirstOrDefault(i => i.AccountId == account.Id),
                Turnover = context.Turnovers
                    .FirstOrDefault(t => t.AccountId == account.Id),
                OutgoingSaldo = context.OutgoingSaldos
                    .FirstOrDefault(o => o.IncomingSaldoId == context.IncomingSaldos
                                         .Where(i => i.AccountId == account.Id)
                                         .Select(i => i.Id)
                                         .FirstOrDefault() &&
                                         o.TurnoverId == context.Turnovers
                                         .Where(t => t.AccountId == account.Id)
                                         .Select(t => t.Id)
                                         .FirstOrDefault())
            })
            .ToList();
            return accountData;
        }
    }
}
