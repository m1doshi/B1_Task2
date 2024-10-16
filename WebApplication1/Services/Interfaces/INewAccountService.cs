using WebApplication1.Models;

namespace WebApplication1.Services.Interfaces
{
    public interface INewAccountService
    {
        Task<int> CreateAccount(NewAccountModel model);
        Task<IEnumerable<NewAccountModel>> GetAllAccounts();
    }
}