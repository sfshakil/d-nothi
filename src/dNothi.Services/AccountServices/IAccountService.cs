using dNothi.Core.Entities;

namespace dNothi.Services.AccountServices
{
  public interface IAccountService
  {
    AppUser LoginUser(string username, string password);
  }
}