using dNothi.JsonParser.Entity;
using System.Threading.Tasks;

namespace dNothi.Services.UserServices
{
    public interface IUserService
    {
        Task<UserMessage> GetUserMessageAsync();
        void SaveOrUpdateUser(UserDTO user);
        void SaveOrUpdateUserEmployeeInfo(EmployeeInfoDTO employeedto);
    }
}