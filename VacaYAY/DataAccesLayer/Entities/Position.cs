using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccesLayer.Entities.Enums;

namespace DataAccesLayer.Entities
{
    public class Position : BaseEntity
    {
        public PositionCaption Caption { get; set; } 
        public string Description { get; set;}
        public ICollection<Employee> Employees { get; set; }
    }
}
