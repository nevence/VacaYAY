using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Dto.EmployeeDto
{
    public record EmployeeDto
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Address { get; init; }
        public string IDNumber { get; init; }
        public int DaysOffNumber { get; init; }
        public int PositionId { get; init; }
        public string PositionCaption { get; init; }
        public DateTime EmploymentStartDate { get; init; }
        public DateTime? EmploymentEndDate { get; init; }
    }
}
