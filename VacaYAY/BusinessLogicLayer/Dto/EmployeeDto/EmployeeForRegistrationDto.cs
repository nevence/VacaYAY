using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Dto.EmployeeDto
{
    public record EmployeeForRegistrationDto
    {
        [Required(ErrorMessage = "This field is required.")]
        public string UserName { get; init; }

        [Required(ErrorMessage = "This field is required.")]
        public string Password { get; init; }

        [Required(ErrorMessage = "This field is required.")]
        public string Role { get; init; }

        [Required]
        public DateTime EmploymentStartDate { get; init; } = DateTime.Now;

        public DateTime? EmploymentEndDate { get; init; }


        [Required(ErrorMessage = "This field is required.")]
        [MaxLength(50, ErrorMessage = "Maximal length of the property is 50.")]
        public string FirstName { get; init; }


        [Required(ErrorMessage = "This field is required.")]
        [MaxLength(50, ErrorMessage = "Maximal length of the property is 50.")]
        public string LastName { get; init; }


        [Required(ErrorMessage = "This field is required.")]
        [MaxLength(50, ErrorMessage = "Maximal length of the property is 50.")]
        public string Address { get; init; }


        [Required(ErrorMessage = "This field is required.")]
        public string IDNumber { get; init; }


        [Required(ErrorMessage = "This field is required.")]
        public int DaysOffNumber { get; init; }


        [Required(ErrorMessage = "This field is required.")]
        public int PositionId { get; init; }
    }

}
