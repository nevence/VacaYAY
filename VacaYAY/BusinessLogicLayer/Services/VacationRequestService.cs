using BusinessLogicLayer.Contracts;
using DataAccesLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    internal sealed class VacationRequestService : IVacationRequestService
    {
        private readonly IRepositoryManager _repository;

        public VacationRequestService(IRepositoryManager repository)
        {
            _repository = repository;
        }
    }
}
