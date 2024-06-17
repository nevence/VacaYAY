using BusinessLogicLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Dto.EmployeeDto
{
    public record EmployeeForManipulationDto
    {
        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [MaxLength(50, ErrorMessage = ErrorMessages.MaxLength50)]
        [DisplayName(DisplayNameEmployee.FirstName)]
        public string FirstName { get; init; }

        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [MaxLength(50, ErrorMessage = ErrorMessages.MaxLength50)]
        [DisplayName(DisplayNameEmployee.LastName)]

        public string LastName { get; init; }

        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [MaxLength(50, ErrorMessage = ErrorMessages.MaxLength50)]
        public string Address { get; init; }

        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        public string IDNumber { get; init; }

        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [DisplayName(DisplayNameEmployee.DaysOffNumber)]
        public int DaysOffNumber { get; init; }

        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [DisplayName(DisplayNameEmployee.PositionId)]
        public int PositionId { get; init; }

        [DisplayName(DisplayNameEmployee.EmploymentEndDate)]
        public DateTime? EmploymentEndDate { get; init; }
    }
}
