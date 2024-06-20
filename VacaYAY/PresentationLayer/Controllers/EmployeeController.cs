using BusinessLogicLayer.Contracts;
using BusinessLogicLayer.Dto.EmployeeDto;
using BusinessLogicLayer.Dto.VacationRequestDto;
using BusinessLogicLayer.Exceptions;
using BusinessLogicLayer.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.ActionFilters;

namespace PresentationLayer.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IServiceManager _service;

        public EmployeeController(ILogger<EmployeeController> logger, IServiceManager service)
        {
            _logger = logger;
            _service = service;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();  
        }
             
        [HttpPost]
        public async Task<IActionResult> Login(EmployeeForAuthenticationDto employeeForAuth)
        {
            var result = await _service.AuthService.Login(employeeForAuth);

            TempData[SuccessMessages.SuccessMessage] = SuccessMessages.EmployeeLogin;
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Logout()
        {
            await _service.AuthService.Logout();
            return RedirectToAction(nameof(Index));
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
    }
}
