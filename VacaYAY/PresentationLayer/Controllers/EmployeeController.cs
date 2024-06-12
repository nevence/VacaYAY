using BusinessLogicLayer.Contracts;
using BusinessLogicLayer.Dto.EmployeeDto;
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
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Login(EmployeeForAuthenticationDto employeeForAuth)
        {
            var result = await _service.AuthService.Login(employeeForAuth);
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
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Register(EmployeeForRegistrationDto employeeForRegistration)
        {
            var result = await _service.AuthService.RegisterUser(employeeForRegistration);
            return RedirectToAction(nameof(Index));
        }


    }
}
