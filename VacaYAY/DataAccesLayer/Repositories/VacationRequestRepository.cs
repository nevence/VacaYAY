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
    }
}
