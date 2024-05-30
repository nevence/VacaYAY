using DataAccesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DataAccesLayer.Contracts
{
    public interface IPositionRepository : IRepositoryBase<Position>
    {
        Task<(IEnumerable<Position> entities, int count)> GetAllPoitionsAsync(int pageNumber, int pageSize, string searchTerm);
    }
}
