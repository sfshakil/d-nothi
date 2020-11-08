using dNothi.JsonParser.Entity;
using System.Threading.Tasks;

namespace dNothi.Services.UserServices
{
    public interface IUserService
    {
        EmployeeInfoDTO GetEmployeeInfo();
        Task<UserMessage> GetUserMessageAsync(UserParam userParam);
        void SaveOrUpdateUser(UserDTO user);
        void SaveOrUpdateUserEmployeeInfo(EmployeeInfoDTO employeedto);
    }
}