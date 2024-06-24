using BusinessLogicLayer.Contracts;
using BusinessLogicLayer.Dto.EmployeeDto;
using BusinessLogicLayer.Dto.VacationRequestDto;
using BusinessLogicLayer.Exceptions;
using BusinessLogicLayer.ViewModel;
using DataAccesLayer.Configuration;
using DataAccesLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.ActionFilters;
using PresentationLayer.Areas.HR.Controllers;

namespace PresentationLayer.Controllers
{
    [Authorize(Roles = ApiRoutes.EmployeeRoute)]
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

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(EmployeeForAuthenticationDto employeeForAuth)
        {
            var result = await _service.AuthService.Login(employeeForAuth);

            if (User.IsInRole(Enums.Roles.HR.ToString()))
            {
                TempData[SuccessMessages.SuccessMessage] = SuccessMessages.EmployeeLogin;
                return RedirectToAction(
                      "Index", "Employee", new { Area = ApiRoutes.HRRoute }
                  );
            }
            else
            {
                TempData[SuccessMessages.SuccessMessage] = SuccessMessages.EmployeeLogin;
                return RedirectToAction(nameof(Index));
            }   
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await _service.AuthService.Logout();
            return RedirectToAction(nameof(Login));

        }
    }
}
