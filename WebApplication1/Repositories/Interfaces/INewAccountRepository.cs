using WebApplication1.Entities;

namespace WebApplication1.Repositories.Interfaces
{
    public interface INewAccountRepository
    {
        Task<int> CreateAccount(NewAccountEntity entity);
        Task<IEnumerable<NewAccountEntity>> GetAllAccounts();
        Task<IEnumerable<NewAccountEntity>> GetAccountsByFileId(int id);
    }
}