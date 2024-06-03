using BusinessLogicLayer.Contracts;
using BusinessLogicLayer.Dto.EmployeeDto;
using BusinessLogicLayer.Dto.OldEmployeeDto;
using BusinessLogicLayer.Exceptions;
using BusinessLogicLayer.Extensions;
using BusinessLogicLayer.ViewModel;
using DataAccesLayer.Configuration;
using DataAccesLayer.Contracts;
using DataAccesLayer.Entities;
using DataAccesLayer.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
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
        private readonly IRepositoryManager _repository;
        private readonly UserManager<Employee> _userManager;
        private readonly SignInManager<Employee> _signInManager;
        private readonly HttpClient _httpClient;
        private readonly ApiConfig _api;

        public AuthService(UserManager<Employee> userManager, SignInManager<Employee> signInManager,
            HttpClient httpClient, IOptions<ApiConfig> api, IRepositoryManager repository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _httpClient = httpClient;
            _api = api.Value;
            _repository = repository;
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

        public async Task<bool> MigrateEmployeesFromOldSystem()
        {
            using var transaction = await _repository.BeginTransactionAsync();

            try
            {
                var response = await _httpClient.GetAsync(_api.BaseUrl + "/Employees");
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var employees = JsonConvert.DeserializeObject<List<OldEmployee>>(apiResponse);

                    foreach (var employee in employees)
                    {
                        var position = await _repository.Position
                            .FindByCondition(p => p.Caption.ToString() == employee.Position.Name, false)
                            .SingleOrDefaultAsync();
                        Guard.ThrowIfNotFoundString(position);

                        var positionId = position.Id;

                        var employeeForRegistration = employee.MapToEmployeeForRegistration(positionId);
                        await RegisterUser(employeeForRegistration);
                    }

                    await transaction.CommitAsync();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new InvalidOperationException(ErrorMessages.EmployeeMigrationError, ex);
            }
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
