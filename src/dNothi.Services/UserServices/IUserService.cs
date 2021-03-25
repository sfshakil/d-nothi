using dNothi.JsonParser.Entity;
using dNothi.Services.DakServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dNothi.Services.UserServices
{
    public interface IUserService
    {
        List<OfficeInfoDTO> GetAllLocalOfficeInfo();

        EmployeDakNothiCountResponse GetDakNothiCountResponseUsingEmployeeDesignation(DakUserParam userParam);

        void MakeThisOfficeCurrent(int designationId);
        EmployeeInfoDTO GetEmployeeInfo();
        OfficeInfoDTO GetOfficeInfo();

        void DeleteLocalOfficeInfo();
        string GetToken();
        Task<UserMessage> GetUserMessageAsync(UserParam userParam);
        void SaveOrUpdateUser(UserDTO user);
        void SaveOrUpdateUserEmployeeInfo(EmployeeInfoDTO employeedto);
        void SaveOrUpdateUserOfficeInfo(List<OfficeInfoDTO> officeInfoDTO);
        void SaveOrUpdateToken(string token);
        DakUserParam GetLocalDakUserParam();

        bool ValidatePassword(char passChar);
        string InvalidPasswordMessage();

     
    }
}