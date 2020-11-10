using dNothi.JsonParser.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dNothi.Services.UserServices
{
    public interface IUserService
    {
        EmployeeInfoDTO GetEmployeeInfo();
        OfficeInfoDTO GetOfficeInfo();
        Task<UserMessage> GetUserMessageAsync(UserParam userParam);
        void SaveOrUpdateUser(UserDTO user);
        void SaveOrUpdateUserEmployeeInfo(EmployeeInfoDTO employeedto);
        void SaveOrUpdateUserOfficeInfo(List<OfficeInfoDTO> officeInfoDTO);
    }
}