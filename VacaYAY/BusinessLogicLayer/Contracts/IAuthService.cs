using BusinessLogicLayer.Dto.EmployeeDto;
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
        Task<IEnumerable<EmployeeDto>> GetUsers();
        Task<EmployeeDto> GetUser(int employeeId);
        Task Logout();
    }
}
