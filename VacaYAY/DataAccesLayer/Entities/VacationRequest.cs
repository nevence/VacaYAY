using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccesLayer.Entities.Enums;

namespace DataAccesLayer.Entities
{
    public class VacationRequest : BaseEntity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public VacationRequestStatus Status { get; set; } = VacationRequestStatus.Pending;
        public VacationRequestLeaveType LeaveType { get; set; }
        public string? HRComment { get; set; }
        public string? EmployeeComment { get; set; } 
        public DateTime RequestDate { get; init; } = DateTime.Now;
    }
}
