using DataAccesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Contracts
{
    public interface IVacationRequestRepository
    {
        Task<IEnumerable<VacationRequest>> GetAllVacationRequestsAsync(int employeeId, bool trackChanges);
        Task<VacationRequest> GetVacationRequestAsync(int employeeId, int requestId, bool trackChanges);
        void CreateVacationRequest(int employeeId, VacationRequest request);
        void DeleteVacationRequest(VacationRequest request);
    }
}
