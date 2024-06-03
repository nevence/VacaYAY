using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OldVacaYAYApi.Services;

namespace OldVacaYAYApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IOldVacaYAYService _service;

        public EmployeesController(IOldVacaYAYService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult GetEmployees()
        {
            var result = _service.GetEmployeesFromOldSystem();
            return Ok(result);
        }
    }
}
