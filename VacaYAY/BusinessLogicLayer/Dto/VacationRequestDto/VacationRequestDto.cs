using DataAccesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccesLayer.Entities.Enums;

namespace BusinessLogicLayer.Dto.VacationRequestDto
{
    public record VacationRequestDto
    {
        public int Id { get; init; }
        public int EmployeeId { get; init; }
        public string FullName {  get; init; }
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }
        public VacationRequestStatus Status { get; init; }
        public VacationRequestLeaveType LeaveType { get; init; }
        public string? HRComment { get; init; }
        public string? EmployeeComment { get; set; }
        public DateTime RequestDate { get; init; }

    }
}
