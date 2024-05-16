using BusinessLogicLayer.Contracts;
using BusinessLogicLayer.Dto.EmployeeDto;
using BusinessLogicLayer.Exceptions;
using BusinessLogicLayer.Extensions;
using DataAccesLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<Employee> _userManager;
        private readonly SignInManager<Employee> _signInManager;

        public AuthService(UserManager<Employee> userManager, SignInManager<Employee> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> ChangePassword(int employeeId, ChangePasswordDto changePassword)
        {
            var user = await _userManager.FindByIdAsync(employeeId.ToString());
            if (user == null)
            {
                throw new NotFoundException(employeeId);
            }

            var result = await _userManager.ChangePasswordAsync(user, changePassword.CurrentPassword, changePassword.NewPassword);
            return result;
        }

        public async Task<IdentityResult> DeleteUser(int employeeId)
        {
            var user = await _userManager.FindByIdAsync(employeeId.ToString());
            if (user == null)
            {
                throw new NotFoundException(employeeId);
            }

            user.IsDeleted = true;
            user.DeleteDate = DateTime.UtcNow;
            user.LockoutEnabled = true;
            user.LockoutEnd = DateTime.UtcNow.AddYears(100);

            var result = await _userManager.UpdateAsync(user);
            return result;
        }

        public IEnumerable<EmployeeDto> GetUsers()
        {
            var users = _userManager.Users
            .OrderBy(u => u.LastName)
            .ToList();

            var employeesDto = users.MapToEmployeesDto().ToList();

            return employeesDto;
        }

        public async Task<SignInResult> Login(EmployeeForAuthenticationDto employeeForAuth)
        {
            var result = await _signInManager.PasswordSignInAsync(employeeForAuth.UserName, employeeForAuth.Password, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                throw new BadRequestException("Something went wrong while signing in.");
            }

            return result;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> RegisterUser(EmployeeForRegistrationDto employeeForRegistration)
        {
            var employee = employeeForRegistration.MapToEmployeeRegistration();
            var result = await _userManager.CreateAsync(employee,
                employeeForRegistration.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(employee, employeeForRegistration.Role);
            }

            return result;
        }

        public async Task<IdentityResult> UpdateUser(int employeeId, EmployeeForUpdateDto employeeForUpdate)
        {
            var user = await _userManager.FindByIdAsync(employeeId.ToString());
            if (user == null)
            {
                throw new Exception(employeeId.ToString());
            }
            var updatedEmployee = user.MapToEmployeeUpdate(employeeForUpdate);
            updatedEmployee.UpdateDate = DateTime.UtcNow;
            var result = await _userManager.UpdateAsync(updatedEmployee);
            return result;
        }
    }

}
