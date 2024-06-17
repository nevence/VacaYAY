using BusinessLogicLayer.Contracts;
using DataAccesLayer.Contracts;
using DataAccesLayer.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PresentationLayer.ViewComponents
{
    public class PositionsDropdownViewComponent : ViewComponent
    {
        private readonly IServiceManager _service;

        public PositionsDropdownViewComponent(IServiceManager service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var positions = await _service.PositionService.GetPositionsForDropdownAsync();
            return View(positions);
        }
    }
}
