using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccesLayer.Entities.Enums;

namespace BusinessLogicLayer.Dto.EmployeeDto
{
    public record EmployeeDto
    {
        public int Id { get; set; }

        [DisplayName(DisplayNameEmployee.FirstName)]
        public string FirstName { get; init; }

        [DisplayName(DisplayNameEmployee.LastName)]
        public string LastName { get; init; }

        public string Address { get; init; }

        public string IDNumber { get; init; }

        [DisplayName(DisplayNameEmployee.DaysOffNumber)]
        public int DaysOffNumber { get; init; }

        [DisplayName(DisplayNameEmployee.PositionId)]
        public int PositionId { get; init; }

        public PositionCaption PositionCaption { get; init; }

        [DisplayName(DisplayNameEmployee.EmploymentStartDate)]
        public DateTime EmploymentStartDate { get; init; }

        [DisplayName(DisplayNameEmployee.EmploymentEndDate)]
        public DateTime? EmploymentEndDate { get; init; }
    }
}
