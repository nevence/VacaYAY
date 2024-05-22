using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccesLayer.Entities.Enums;

namespace BusinessLogicLayer.Dto.VacationRequestDto
{
    public record VacationRequesForManipulationtDto
    {
        public VacationRequestStatus Status { get; set; } = VacationRequestStatus.Pending;

        [Required(ErrorMessage = "This field is required.")]
        public VacationRequestLeaveType LeaveType { get; set; }

        public string? HRComment { get; set; }

        public string? EmployeeComment { get; set; }
    }
}