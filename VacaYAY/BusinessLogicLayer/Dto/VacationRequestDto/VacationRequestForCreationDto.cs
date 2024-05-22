using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Dto.VacationRequestDto
{
    public record VacationRequestForCreationDto : VacationRequesForManipulationtDto
    {
        [Required(ErrorMessage = "This field is required.")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public DateTime EndDate { get; set; }
        public DateTime RequestDate { get; init; } = DateTime.UtcNow;
    }
}
