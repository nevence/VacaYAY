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

        public void CreateVacationRequest(int employeeId, VacationRequest request)
        {
            request.EmployeeId = employeeId;
            Create(request);
        }

        public void DeleteVacationRequest(VacationRequest request)
        {
            Delete(request);
        }

        public async Task<IEnumerable<VacationRequest>> GetAllVacationRequestsAsync(int employeeId, bool trackChanges) =>
            await FindByCondition(v => v.EmployeeId.Equals(employeeId), trackChanges)
            .OrderBy(v => v.InsertDate)
            .ToListAsync();


        public async Task<VacationRequest> GetVacationRequestAsync(int employeeId, int requestId, bool trackChanges) =>
            await FindByCondition(v => v.EmployeeId.Equals(employeeId) && v.Id.Equals(requestId), trackChanges).SingleOrDefaultAsync();
    }
}
