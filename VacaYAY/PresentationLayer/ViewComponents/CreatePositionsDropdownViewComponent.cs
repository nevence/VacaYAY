using BusinessLogicLayer.Contracts;
using BusinessLogicLayer.ViewModel;
using Microsoft.AspNetCore.Mvc;
using static DataAccesLayer.Entities.Enums;

namespace PresentationLayer.ViewComponents
{
    public class CreatePositionsDropdownViewComponent : ViewComponent
    {
        private readonly IServiceManager _service;

        public CreatePositionsDropdownViewComponent(IServiceManager service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var existingPositions = await _service.PositionService.GetPositionsForDropdownAsync();

            var allCaptions = Enum.GetValues(typeof(PositionCaption)).Cast<PositionCaption>();

            var unusedCaptions = allCaptions.Except(existingPositions.Select(p => p.Caption).ToList()).ToList();

            return View(unusedCaptions);
        }
    }
}
