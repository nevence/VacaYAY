using BusinessLogicLayer.Contracts;
using BusinessLogicLayer.Dto.VacationRequestDto;
using BusinessLogicLayer.ViewModel;
using DataAccesLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace PresentationLayer.Controllers
{
    [Authorize]
    public class VacationRequestController : Controller
    {
        private readonly ILogger<VacationRequestController> _logger;
        private readonly IServiceManager _service;

        public VacationRequestController(ILogger<VacationRequestController> logger, IServiceManager service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> Index(RequestParameters parameters)
        {
            if(User.IsInRole(Enums.Roles.HR.ToString()))
            {
                var result = await _service.VacationRequestService.GetVacationRequestsAsync(parameters);
                return View(result);
            }
            else
            {
                var result = await _service.VacationRequestService.GetVacationRequestsForEmployeeAsync(
                    parameters, int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value)
                    );
                return View(result);
            }
   
        }

        public async Task<IActionResult> Details(int id)
        {
            var request = await _service.VacationRequestService.GetVacationRequestAsync(id);
            return View(request);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var request = await _service.VacationRequestService.GetVacationRequestAsync(id);
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, VacationRequestForUpdateDto request)
        {
            await _service.VacationRequestService.UpdateVacationRequestAsync(id, request);

            TempData[SuccessMessages.SuccessMessage] = SuccessMessages.Edit;
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Reject(int id)
        {
            var request = await _service.VacationRequestService.GetVacationRequestAsync(id);
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Reject(int id, bool notUsed)
        {
            await _service.VacationRequestService.RejectVacationRequestAsync(id);

            TempData[SuccessMessages.SuccessMessage] = SuccessMessages.RequestReject;
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Approve(int id)
        {
            var request = await _service.VacationRequestService.GetVacationRequestAsync(id);
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Approve(int id, bool notUsed)
        {
            await _service.VacationRequestService.ApproveVacationRequestAsync(id);

            TempData[SuccessMessages.SuccessMessage] = SuccessMessages.RequestApprove;
            return RedirectToAction(nameof(Index));
        }
    }
}
