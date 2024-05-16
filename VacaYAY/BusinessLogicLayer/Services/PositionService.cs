using BusinessLogicLayer.Contracts;
using DataAccesLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    internal sealed class PositionService : IPositionService
    {
        private readonly IRepositoryManager _repository;

        public PositionService(IRepositoryManager repository)
        {
            _repository = repository;
        }
    }
}
