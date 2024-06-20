using DataAccesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccesLayer.Entities.Enums;

namespace DataAccesLayer.Contracts
{
    public interface IVacationRequestRepository : IRepositoryBase<VacationRequest>
    {
        Task<(IEnumerable<VacationRequest> entities, int count)> GetAllVacationRequestsForEmployeeAsync(int pageNumber, int pageSize, int employeeId, VacationRequestLeaveType leaveType, VacationRequestStatus status);
        Task<(IEnumerable<VacationRequest> entities, int count)> GetAllVacationRequestsAsync(int pageNumber, int pageSize, string searchTerm, VacationRequestLeaveType leaveType, VacationRequestStatus status);
    }
}
