using BusinessLogicLayer.Contracts;
using BusinessLogicLayer.Dto.EmployeeDto;
using BusinessLogicLayer.Exceptions;
using BusinessLogicLayer.Extensions;
using BusinessLogicLayer.ViewModel;
using DataAccesLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BusinessLogicLayer.Services
{
    public sealed class AuthService : IAuthService
    {
        private readonly UserManager<Employee> _userManager;
        private readonly SignInManager<Employee> _signInManager;

        public AuthService(UserManager<Employee> userManager, SignInManager<Employee> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<bool> ChangePassword(int employeeId, ChangePasswordDto changePassword)
        {
            var user = await _userManager.FindByIdAsync(employeeId.ToString());

            Guard.ThrowIfNotFound(user, employeeId);

            var result = await _userManager.ChangePasswordAsync(user, changePassword.CurrentPassword, changePassword.NewPassword);

            Guard.ThrowIfFailedIdentity(result);

            return result.Succeeded;
        }

        public async Task<bool> DeleteUser(int employeeId)
        {
            var user = await _userManager.FindByIdAsync(employeeId.ToString());

            Guard.ThrowIfNotFound(user, employeeId);

            user.MapToEmployeeDelete();

            var result = await _userManager.UpdateAsync(user);

            Guard.ThrowIfFailedIdentity(result);

            return result.Succeeded;

        }

        public async Task<EmployeeDto> GetUser(int employeeId)
        {
            var user = await _userManager.FindByIdAsync(employeeId.ToString());

            Guard.ThrowIfNotFound(user, employeeId);

            var employeeDto = user.MapToEmployeeDto();

            return employeeDto;
        }

 

        public async Task<PaginatedResponse<EmployeeDto>> GetUsers(RequestParameters requestParameters)
        {
            var result = await GetUsersAsync(requestParameters);

            var employeesDto = result.entities.MapToEmployeesDto();

            var employeesViewModel = new PaginatedResponse<EmployeeDto>(employeesDto, result.count, requestParameters);

            return employeesViewModel;
        }

        public async Task<bool> Login(EmployeeForAuthenticationDto employeeForAuth)
        {
            var result = await _signInManager.PasswordSignInAsync(employeeForAuth.UserName, employeeForAuth.Password, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException(ErrorMessages.InvalidLogin);
            }

            return result.Succeeded;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> RegisterUser(EmployeeForRegistrationDto employeeForRegistration)
        {
            var employee = employeeForRegistration.MapToEmployeeRegistration();
            var result = await _userManager.CreateAsync(employee,
                employeeForRegistration.Password);

            Guard.ThrowIfFailedIdentity(result);

            var addToRoleresult = await _userManager.AddToRoleAsync(employee, employeeForRegistration.Role);

            Guard.ThrowIfFailedIdentity(addToRoleresult);
            
            return result.Succeeded;
        }

        public async Task<bool> UpdateUser(int employeeId, EmployeeForUpdateDto employeeForUpdate)
        {
            var user = await _userManager.FindByIdAsync(employeeId.ToString());

            Guard.ThrowIfNotFound(user, employeeId);

            user.MapToEmployeeUpdate(employeeForUpdate);

            var result = await _userManager.UpdateAsync(user);

            Guard.ThrowIfFailedIdentity(result);

            return result.Succeeded;
        }

        private async Task<(IEnumerable<Employee> entities, int count)> GetUsersAsync(RequestParameters requestParameters)
        {
            var query = _userManager.Users;

            if (!string.IsNullOrEmpty(requestParameters.SearchTerm))
            {
                query = query.Where(v => v.FirstName.Contains(requestParameters.SearchTerm) || v.LastName.Contains(requestParameters.SearchTerm));
            }

            var _users = await query
                .Skip((requestParameters.PageNumber - 1) * requestParameters.PageSize)
                .Take(requestParameters.PageSize)
                .ToListAsync();

            var _count = await query.CountAsync();
            return (_users, _count); 
        }
    }

}
