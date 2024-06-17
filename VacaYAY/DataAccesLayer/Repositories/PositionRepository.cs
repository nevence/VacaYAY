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
    public class PositionRepository : RepositoryBase<Position>, IPositionRepository
    {
        private readonly ApplicationDbContext _context;

        public PositionRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Position> entities, int count)> GetAllPoitionsAsync(int pageNumber, int pageSize, string searchTerm, PositionCaption caption)
        {
            var query = FindAll(false);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(p => p.Description.Contains(searchTerm));
            }

            if (caption != PositionCaption.None)
            {
                query = query.Where(p => p.Caption.Equals(caption));
            }

            return await GetPaginatedAsync(query, pageNumber, pageSize);
        }
    }
}
