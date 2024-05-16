using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Dto.EmployeeDto
{
    public record EmployeeForManipulationDto
    {
        [MaxLength(50, ErrorMessage = "Maximal length of the property is 50.")]
        public string? FirstName { get; init; }


        [MaxLength(50, ErrorMessage = "Maximal length of the property is 50.")]
        public string? LastName { get; init; }


        [MaxLength(50, ErrorMessage = "Maximal length of the property is 50.")]
        public string? Address { get; init; }

        public string? IDNumber { get; init; }
        public int? DaysOffNumber { get; init; }
        public int? PositionId { get; init; }
        public DateTime? EmploymentEndDate { get; init; }
        public DateTime? DeleteDate { get; init; }
        public DateTime? UpdateTime { get; init; }
    }
}
