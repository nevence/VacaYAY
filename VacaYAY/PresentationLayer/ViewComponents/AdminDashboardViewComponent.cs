using BusinessLogicLayer.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class AdminDashboardViewComponent : ViewComponent
    {
        private readonly IServiceManager _service;

        public AdminDashboardViewComponent(IServiceManager service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var dashboardData = await _service.AuthService.GetAdminDashboardDataAsync();
            return View(dashboardData);
        }
    }
}
