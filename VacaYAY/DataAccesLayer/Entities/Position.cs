using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Entities
{
    public enum PositionCaption
    {
        ITAdministrator,
        SalesExecutive,
        ProcurementOfficer,
        HRManager,
    }
    public class Position : BaseEntity
    {
        public PositionCaption Caption { get; set; } 
        public string Description { get; set;}
        public ICollection<Employee> Employees { get; set; }
    }
}
