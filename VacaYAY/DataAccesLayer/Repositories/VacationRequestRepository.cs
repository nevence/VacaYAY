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

        public async Task<(IEnumerable<VacationRequest> entities, int count)> GetAllByConditionAsync(int pageNumber, int pageSize, int employeeId)
        {
            var _entities = await FindByCondition(v => v.EmployeeId.Equals(employeeId), false)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var _count = await FindByCondition(v => v.EmployeeId.Equals(employeeId), false).CountAsync();

            return (_entities, _count);
        }
    }
}
