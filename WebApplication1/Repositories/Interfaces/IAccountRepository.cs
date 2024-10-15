using WebApplication1.Entities;

namespace WebApplication1.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<int> CreateAccount(AccountEntity entity);
        Task<IEnumerable<AccountEntity>> GetAllAccounts();
    }
}
