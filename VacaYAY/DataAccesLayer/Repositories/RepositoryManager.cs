using DataAccesLayer.Contracts;
using DataAccesLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationDbContext _context;
        private readonly IPositionRepository _positionRepository;
        private readonly IVacationRequestRepository _vacationRequestRepository;

        public RepositoryManager(ApplicationDbContext context)
        {
            _context = context;
            _positionRepository = new PositionRepository(context);
            _vacationRequestRepository = new VacationRequestRepository(context);
        }

        public IPositionRepository Position => _positionRepository;
        public IVacationRequestRepository VacationRequest => _vacationRequestRepository;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
