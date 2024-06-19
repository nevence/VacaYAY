using BusinessLogicLayer.Dto.EmployeeDto;
using BusinessLogicLayer.Dto.OldEmployeeDto;
using DataAccesLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static DataAccesLayer.Entities.Enums;

namespace BusinessLogicLayer.Extensions
{
    public static class EmployeeExtensions
    {
        public static EmployeeDto MapToEmployeeDto(this Employee employee)
        {
            return new EmployeeDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Address = employee.Address,
                IDNumber = employee.IDNumber,
                DaysOffNumber = employee.DaysOffNumber,
                PositionId = employee.PositionId,
                PositionCaption = employee.Position.Caption,
                EmploymentStartDate = employee.EmploymentStartDate,
                EmploymentEndDate = employee.EmploymentEndDate
            };
        }

        public static IEnumerable<EmployeeDto> MapToEmployeesDto(this IEnumerable<Employee> employees)
        {
            return employees.Select(employee => employee.MapToEmployeeDto());
        }


        public static EmployeeForRegistrationDto MapToEmployeeForRegistration(this OldEmployee oldEmployee, int positionId)
        {
            return new EmployeeForRegistrationDto
            {
                FirstName = oldEmployee.FirstName,
                LastName = oldEmployee.LastName,
                Address = $"{oldEmployee.Location.Street}, {oldEmployee.Location.City}, {oldEmployee.Location.Country}",
                IDNumber = oldEmployee.IDNumber,
                DaysOffNumber = oldEmployee.DaysOffNumber,
                PositionId = positionId,
                EmploymentEndDate = oldEmployee.EmploymentEndDate,
                UserName = oldEmployee.Login.UserName,
                Password = oldEmployee.Login.Password,
                Role = Enum.Parse<Roles>(oldEmployee.Login.Role),
                EmploymentStartDate = oldEmployee.EmploymentStartDate
            };
        }
        public static Employee MapToEmployeeRegistration(this EmployeeForRegistrationDto employeeForRegistration)
        {
            return new Employee
            {
                Email = employeeForRegistration.UserName,
                UserName = employeeForRegistration.UserName,
                FirstName = employeeForRegistration.FirstName,
                LastName = employeeForRegistration.LastName,
                Address = employeeForRegistration.Address,
                IDNumber = employeeForRegistration.IDNumber,
                DaysOffNumber = employeeForRegistration.DaysOffNumber,
                PositionId = employeeForRegistration.PositionId,
                EmploymentStartDate = employeeForRegistration.EmploymentStartDate
            };
        }

        public static void MapToEmployeeUpdate(this Employee user, EmployeeForUpdateDto employeeForUpdate)
        {
            user.FirstName = employeeForUpdate.FirstName;
            user.LastName = employeeForUpdate.LastName;
            user.Address = employeeForUpdate.Address;
            user.IDNumber = employeeForUpdate.IDNumber;
            user.DaysOffNumber = employeeForUpdate.DaysOffNumber;
            user.PositionId = employeeForUpdate.PositionId;
            user.EmploymentStartDate = employeeForUpdate.EmploymentStartDate;
            user.EmploymentEndDate = employeeForUpdate.EmploymentEndDate;
            user.UpdateDate = DateTime.UtcNow;

        }

        public static void MapToEmployeeDelete(this Employee user)
        {
            user.IsDeleted = true;
            user.DeleteDate = DateTime.UtcNow;
            user.LockoutEnabled = true;
            user.LockoutEnd = DateTime.UtcNow.AddYears(100);
        }
    }

}
