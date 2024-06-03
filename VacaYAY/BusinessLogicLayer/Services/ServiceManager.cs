using BusinessLogicLayer.Contracts;
using DataAccesLayer.Configuration;
using DataAccesLayer.Contracts;
using DataAccesLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly IAuthService _authService;
        private readonly IPositionService _positionService;
        private readonly IVacationRequestService _vacationRequestService;

        public ServiceManager(IRepositoryManager repositoryManager,
                              UserManager<Employee> userManager,
                              SignInManager<Employee> signInManager, HttpClient httpClient,
                              IOptions<ApiConfig> api)
        {
            _authService = new AuthService(userManager, signInManager, httpClient, api, repositoryManager);
            _positionService = new PositionService(repositoryManager);
            _vacationRequestService = new VacationRequestService(repositoryManager);
        }

        public IAuthService AuthService => _authService;

        public IPositionService PositionService => _positionService;

        public IVacationRequestService VacationRequestService => _vacationRequestService;
    }

}
