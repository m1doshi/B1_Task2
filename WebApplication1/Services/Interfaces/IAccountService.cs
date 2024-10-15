using WebApplication1.Models;

namespace WebApplication1.Services.Interfaces
{
    public interface IAccountService
    {
        Task<int> CreateAccount(AccountModel model);
        Task<IEnumerable<AccountModel>> GetAllAccounts();
    }
}