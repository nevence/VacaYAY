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
        [Required(ErrorMessage = "This field is required.")]
        [MaxLength(50, ErrorMessage = "Maximal length of the property is 50.")]
        public PositionCaption Caption { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        public string Description { get; set; }
    }
}
