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
        Task<IdentityResult> RegisterUser(EmployeeForRegistrationDto employeeForRegistration);
        Task<SignInResult> Login(EmployeeForAuthenticationDto employeeForAuth);
        Task<IdentityResult> DeleteUser(int employeeId);
        Task<IdentityResult> ChangePassword(int employeeId, ChangePasswordDto changePassword);
        Task<IdentityResult> UpdateUser(int employeeId, EmployeeForUpdateDto employeeForUpdate);
        IEnumerable<EmployeeDto> GetUsers();
        Task Logout();
    }
}
