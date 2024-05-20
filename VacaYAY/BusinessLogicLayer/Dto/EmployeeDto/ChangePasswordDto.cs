using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Dto.EmployeeDto
{
    public record ChangePasswordDto
    {
        [Required(ErrorMessage = "This field is required.")]
        public string? CurrentPassword { get; init; }
        [Required(ErrorMessage = "This field is required.")]
        public string? NewPassword { get; init; }
    }
}
