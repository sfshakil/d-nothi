using dNothi.Core.Entities;

namespace dNothi.Services.AccountServices
{
    public interface IAccountService
    {
        void DeleteUser(string userName, string password);
        AppUser LoginUser(string username, string password);
        void SaveOrUpdateUser(string username, string password, bool isRemember);
        void SaveUser(string userName, string password, bool isRemember);
        void UpdateUser(string userName, string password, bool isRemember);
    }
}