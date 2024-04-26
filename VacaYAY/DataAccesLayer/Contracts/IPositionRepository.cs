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

    }
}
