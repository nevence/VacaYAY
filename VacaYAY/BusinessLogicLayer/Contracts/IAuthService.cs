using BusinessLogicLayer.Dto.EmployeeDto;
using BusinessLogicLayer.ViewModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Contracts
{
    public interface IAuthService
    {
        Task<bool> RegisterUser(EmployeeForRegistrationDto employeeForRegistration);
        Task<bool> Login(EmployeeForAuthenticationDto employeeForAuth);
        Task<bool> DeleteUser(int employeeId);
        Task<bool> ChangePassword(int employeeId, ChangePasswordDto changePassword);
        Task<bool> UpdateUser(int employeeId, EmployeeForUpdateDto employeeForUpdate);
        Task<PaginatedResponse<EmployeeDto>> GetUsers(RequestParameters requestParameters);
        Task<EmployeeDto> GetUser(int employeeId);
        Task Logout();
    }
}
