using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Entities
{
    public enum VacationRequestStatus
    {
        Pending,
        Accepted,
        Rejected
    }

    public enum VacationRequestLeaveType
    {
        SickLeave,
        MaternityLeave,
        CasualLeave,
        AnnualLeave
    }
    public class VacationRequest : BaseEntity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public VacationRequestStatus Status { get; set; } = VacationRequestStatus.Pending;
        public VacationRequestLeaveType LeaveType { get; set; }
        public string HRComment { get; set; }
        public string EmployeeComment { get; set; } 
        public DateTime RequestDate { get; init; } = DateTime.Now;
    }
}
