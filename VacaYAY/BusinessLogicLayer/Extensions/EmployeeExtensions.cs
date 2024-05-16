using BusinessLogicLayer.Dto.EmployeeDto;
using DataAccesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Extensions
{
    public static class EmployeeExtensions
    {
        public static EmployeeDto MapToEmployeeDto(this Employee employee)
        {
            return new EmployeeDto
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Address = employee.Address,
                IDNumber = employee.IDNumber,
                DaysOffNumber = employee.DaysOffNumber,
                PositionId = employee.PositionId,
                PositionCaption = employee.Position.Caption.ToString(),
                EmploymentStartDate = employee.EmploymentStartDate,
                EmploymentEndDate = employee.EmploymentEndDate
            };
        }

        public static IEnumerable<EmployeeDto> MapToEmployeesDto(this IEnumerable<Employee> employees)
        {
            return employees.Select(employee => employee.MapToEmployeeDto());
        }

        public static Employee MapToEmployeeRegistration(this EmployeeForRegistrationDto employeeForRegistration)
        {
            return new Employee
            {
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

        public static Employee MapToEmployeeUpdate(this Employee user, EmployeeForUpdateDto employeeForUpdate)
        {
            PropertyInfo[] properties = typeof(EmployeeForUpdateDto).GetProperties();

            foreach (var property in properties)
            {
                var value = property.GetValue(employeeForUpdate);

                if (value != null)
                {
                    var correspondingProperty = typeof(Employee).GetProperty(property.Name);

                    if (correspondingProperty != null)
                    {
                        correspondingProperty.SetValue(user, value);
                    }
                }
            }
            return user;

        }
    }

}
