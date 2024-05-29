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
    public class PositionRepository : RepositoryBase<Position>, IPositionRepository
    {
        private readonly ApplicationDbContext _context;

        public PositionRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Position> entities, int count)> GetAllPoitionsAsync(int pageNumber, int pageSize, string searchTerm)
        {
            var query = FindAll(false);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(v => v.Caption.ToString().Contains(searchTerm) || v.Description.Contains(searchTerm));
            }

            var entities = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var count = await query.CountAsync();

            return (entities, count);
        }
    }
}
