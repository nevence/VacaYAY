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
    public record EmployeeForAuthenticationDto(
     [Required(ErrorMessage = ErrorMessages.RequiredField)]
    string Username,

     [Required(ErrorMessage = ErrorMessages.RequiredField)]
    string Password
 );


}
