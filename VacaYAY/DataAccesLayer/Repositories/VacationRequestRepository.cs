using DataAccesLayer.Contracts;
using DataAccesLayer.Data;
using DataAccesLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccesLayer.Entities.Enums;

namespace DataAccesLayer.Repositories
{
    public class VacationRequestRepository : RepositoryBase<VacationRequest>, IVacationRequestRepository
    {
        private readonly ApplicationDbContext _context;
        public VacationRequestRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<VacationRequest> entities, int count)> GetAllVacationRequestsAsync(int pageNumber, int pageSize, string searchTerm, VacationRequestLeaveType leaveType, VacationRequestStatus status)
        {
            var query = FindAll(false).Include(v => v.Employee).AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(v => v.Employee.FirstName.Contains(searchTerm) || v.Employee.LastName.Contains(searchTerm));
            }

            if (status != VacationRequestStatus.None)
            {
                query = query.Where(v => v.Status.Equals(status));
            }

            if (leaveType != VacationRequestLeaveType.None)
            {
                query = query.Where(v => v.LeaveType.Equals(leaveType));    
            }

            return await GetPaginatedAsync(query, pageNumber, pageSize);

        }

        public async Task<(IEnumerable<VacationRequest> entities, int count)> GetAllVacationRequestsForEmployeeAsync(int pageNumber, int pageSize, int employeeId, VacationRequestLeaveType leaveType, VacationRequestStatus status)
        {
            var query = FindByCondition(v => v.EmployeeId == employeeId, false).Include(v => v.Employee).AsQueryable();

            if (status != VacationRequestStatus.None)
            {
                query = query.Where(v => v.Status.Equals(status));
            }

            if (leaveType != VacationRequestLeaveType.None)
            {
                query = query.Where(v => v.LeaveType.Equals(leaveType));
            }

            return await GetPaginatedAsync(query, pageNumber, pageSize);
        }
    }
}
