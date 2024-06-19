using BusinessLogicLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccesLayer.Entities.Enums;

namespace BusinessLogicLayer.Dto.EmployeeDto
{
    public record EmployeeForRegistrationDto : EmployeeForManipulationDto
    {
        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [DisplayName(DisplayNameEmployee.UserName)]
        public string UserName { get; init; }

        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        public string Password { get; init; }

        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        public Roles Role { get; init; }
    }

}
