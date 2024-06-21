using BusinessLogicLayer.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ViewModel
{
    public class UserDaysOffViewComponent : ViewComponent
    {
        private readonly IServiceManager _service;

        public UserDaysOffViewComponent(IServiceManager service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var user = await _service.AuthService.GetUser(id);
            return View(user.DaysOffNumber);
        }
    }
}
