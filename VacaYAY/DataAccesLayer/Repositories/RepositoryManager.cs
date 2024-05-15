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
        private readonly Lazy<IPositionRepository> _positionRepository;
        private readonly Lazy<IVacationRequestRepository> _vacationRequestRepository;

        public RepositoryManager(ApplicationDbContext context)
        {
            _context = context;

            _positionRepository = new Lazy<IPositionRepository>(() =>
            new PositionRepository(context));

            _vacationRequestRepository = new Lazy<IVacationRequestRepository>(() => new VacationRequestRepository(context));
           
        }
        public IPositionRepository Position => _positionRepository.Value;

        public IVacationRequestRepository VacationRequest => _vacationRequestRepository.Value;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();

        }
    }
}
