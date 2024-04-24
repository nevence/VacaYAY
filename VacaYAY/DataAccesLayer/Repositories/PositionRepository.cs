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

        public void CreatePosition(Position position)
        {
            Create(position);
        }

        public void DeletePosition(Position position)
        {
            Delete(position);
        }

        public async Task<IEnumerable<Position>> GetAllPositionsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(p => p.InsertDate)
            .ToListAsync();

        public async Task<Position> GetPositionAsync(int positionId, bool trackChanges) =>
            await FindByCondition(p => p.Id.Equals(positionId), trackChanges).SingleOrDefaultAsync();
    }
}
