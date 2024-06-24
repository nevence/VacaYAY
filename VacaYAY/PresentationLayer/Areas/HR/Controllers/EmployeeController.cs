using BusinessLogicLayer.Contracts;
using BusinessLogicLayer.Dto.EmployeeDto;
using BusinessLogicLayer.Exceptions;
using BusinessLogicLayer.ViewModel;
using DataAccesLayer.Configuration;
using DataAccesLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using static DataAccesLayer.Entities.Enums;

namespace PresentationLayer.Areas.HR.Controllers
{
    [Area(ApiRoutes.HRRoute)]
    [Authorize(Roles = ApiRoutes.HRRoute)]
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IServiceManager _service;

        public EmployeeController(ILogger<EmployeeController> logger, IServiceManager service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(EmployeeForRegistrationDto employeeForRegistration)
        {
            var result = await _service.AuthService.RegisterUser(employeeForRegistration);

            TempData[SuccessMessages.SuccessMessage] = SuccessMessages.EmployeeRegister;
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Employees(RequestParameters parameters)
        {
            var result = await _service.AuthService.GetUsers(parameters);
            return View(result);
        }
        public async Task<IActionResult> Details(int id)
        {
            var employee = await _service.AuthService.GetUser(id);
            return View(employee);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _service.AuthService.GetUser(id);
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EmployeeForUpdateDto employee)
        {
            await _service.AuthService.UpdateUser(id, employee);

            TempData[SuccessMessages.SuccessMessage] = SuccessMessages.Edit;
            return RedirectToAction(nameof(Employees));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _service.AuthService.GetUser(id);
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, bool notUsed)
        {
            var result = await _service.AuthService.DeleteUser(id);

            TempData[SuccessMessages.SuccessMessage] = SuccessMessages.Delete;
            return RedirectToAction(nameof(Employees));
        }

        public IActionResult Load()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Load(bool notUsed)
        {
            await _service.AuthService.MigrateEmployeesFromOldSystem();

            TempData[SuccessMessages.SuccessMessage] = SuccessMessages.MigrateEmployees;
            return RedirectToAction(nameof(Employees));
        }
    }
}
