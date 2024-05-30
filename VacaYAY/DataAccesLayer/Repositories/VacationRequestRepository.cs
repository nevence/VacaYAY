using DataAccesLayer.Contracts;
using DataAccesLayer.Data;
using DataAccesLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Repositories
{
    public class VacationRequestRepository : RepositoryBase<VacationRequest>, IVacationRequestRepository
    {
        private readonly ApplicationDbContext _context;
        public VacationRequestRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<VacationRequest> entities, int count)> GetAllVacationRequestsAsync(int pageNumber, int pageSize, string searchTerm)
        {
            var query = FindAll(false);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(v => v.Employee.FirstName.Contains(searchTerm) || v.Employee.LastName.Contains(searchTerm)
                || v.Status.ToString().Contains(searchTerm));
            }

            return await GetPaginatedAsync(query, pageNumber, pageSize);

        }

        public async Task<(IEnumerable<VacationRequest> entities, int count)> GetAllVacationRequestsForEmployeeAsync(int pageNumber, int pageSize, int employeeId, string searchTerm)
        {
            var query = FindByCondition(v => v.EmployeeId == employeeId, false);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(v => v.Status.ToString().Contains(searchTerm));
            }

            return await GetPaginatedAsync(query, pageNumber, pageSize);
        }
    }
}
