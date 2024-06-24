using BusinessLogicLayer.Contracts;
using BusinessLogicLayer.Dto.EmployeeDto;
using BusinessLogicLayer.Dto.PositionDto;
using BusinessLogicLayer.Exceptions;
using BusinessLogicLayer.ViewModel;
using DataAccesLayer.Configuration;
using DataAccesLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.HR.Controllers
{
    [Area(ApiRoutes.HRRoute)]
    [Authorize(Roles = ApiRoutes.HRRoute)]
    public class PositionController : Controller
    {
        private readonly ILogger<PositionController> _logger;
        private readonly IServiceManager _service;

        public PositionController(ILogger<PositionController> logger, IServiceManager service)
        {
            _logger = logger;
            _service = service;
        }
        public async Task<IActionResult> Index(RequestParameters parameters)
        {
            var positions = await _service.PositionService.GetPositionsAsync(parameters);
            return View(positions);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PositionForCreationDto position)
        {
            await _service.PositionService.CreatePositionAsync(position);

            TempData[SuccessMessages.SuccessMessage] = SuccessMessages.PositionCreate;
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int id)
        {
            var position = await _service.PositionService.GetPositionAsync(id);
            return View(position);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PositionForUpdateDto position)
        {
            await _service.PositionService.UpdatePositionAsync(id, position);

            TempData[SuccessMessages.SuccessMessage] = SuccessMessages.Edit;
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var position = await _service.PositionService.GetPositionAsync(id);
            return View(position);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, bool notUsed)
        {
            await _service.PositionService.DeletePositionAsync(id);

            TempData[SuccessMessages.SuccessMessage] = SuccessMessages.Delete;
            return RedirectToAction(nameof(Index));
        }
    }
}
