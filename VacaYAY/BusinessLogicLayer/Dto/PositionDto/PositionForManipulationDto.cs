using BusinessLogicLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccesLayer.Entities.Enums;

namespace BusinessLogicLayer.Dto.PositionDto
{
    public record PositionForManipulationDto
    {
        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        public PositionCaption Caption { get; set; }


        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        public string Description { get; set; }
    }
}
