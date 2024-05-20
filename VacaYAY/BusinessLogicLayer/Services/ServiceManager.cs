using BusinessLogicLayer.Contracts;
using DataAccesLayer.Contracts;
using DataAccesLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthService> _authService;


        public ServiceManager(IRepositoryManager repositoryManager,
            UserManager<Employee> userManager, SignInManager<Employee> signInManager)
        {

            _authService = new Lazy<IAuthService>(() => new AuthService(userManager, signInManager));
        }

        public IAuthService AuthService => _authService.Value;
    }

}
