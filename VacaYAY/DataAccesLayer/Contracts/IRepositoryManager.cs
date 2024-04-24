using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Contracts
{
    public interface IRepositoryManager
    {
        IVacationRequestRepository VacationRequest { get; }
        IPositionRepository Position { get; }
        Task SaveAsync();
    }
}
