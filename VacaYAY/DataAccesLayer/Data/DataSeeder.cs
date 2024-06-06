using DataAccesLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DataAccesLayer.Entities.Enums;

namespace DataAccesLayer.Data
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Employee> _userManager;

        public DataSeeder(ApplicationDbContext context, UserManager<Employee> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task SeedEmployeesAndPositionsAsync()
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (!_context.Positions.Any())
                    {
                        var positions = new List<Position>
                        {
                            new Position { Caption = PositionCaption.HRManager, Description = "HR Manager position" },
                            new Position { Caption = PositionCaption.ProcurementOfficer, Description = "Procurement position" }
                        };

                        _context.Positions.AddRange(positions);
                        _context.SaveChanges();
                    }

                    if (!_userManager.Users.Any())
                    {
                        var employees = new List<Employee>
                        {
                            new Employee { UserName = "nevenceminic@gmail.com", Email="nevenceminic@gmail.com", FirstName = "John", LastName = "Doe", PositionId = 1,
                                               Address = "A.M. 20", IDNumber = "123456789", DaysOffNumber = 20,
                                               EmploymentStartDate = DateTime.Now.AddDays(-365)},

                            new Employee { UserName = "bananagrana000@gmail.com", Email="bananagrana000@gmail.com", FirstName = "Jane", LastName = "Smith", PositionId = 2,
                                               Address = "A.M. 10", IDNumber = "987654321", DaysOffNumber = 22,
                                               EmploymentStartDate = DateTime.Now.AddDays(-180) },
                        };

                        foreach (var employee in employees)
                        {
                            var result = await _userManager.CreateAsync(employee, "Lozinka123.");

                            if (result.Succeeded)
                            {
                                if (employee.FirstName == "John")
                                    await _userManager.AddToRoleAsync(employee, "HR");
                                else
                                    await _userManager.AddToRoleAsync(employee, "Employee");
                            }
                            else
                            {
                                foreach (var error in result.Errors)
                                {
                                    Console.WriteLine($"Error: {error.Code} - {error.Description}");
                                }
                            }
                        }
                    }
                   transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    transaction.Rollback();
                }
            }
        }

        public void SeedVacationRequests()
        {
            if (!_context.VacationRequests.Any())
            {
                var vacationRequests = new List<VacationRequest>
                {
                    new VacationRequest { EmployeeId = 1, StartDate = DateTime.Now.Date, EndDate = DateTime.Now.Date.AddDays(5), LeaveType = VacationRequestLeaveType.SickLeave, HRComment = "Komentar", EmployeeComment = "Komentar", RequestDate = DateTime.Now.Date },
                    new VacationRequest { EmployeeId = 2, StartDate = DateTime.Now.Date, EndDate = DateTime.Now.Date.AddDays(3), LeaveType = VacationRequestLeaveType.CasualLeave, HRComment = "Komentar", EmployeeComment = "Komentar", RequestDate = DateTime.Now.Date },
                };

                _context.VacationRequests.AddRange(vacationRequests);
                _context.SaveChanges();
            }
        }
    }
}
