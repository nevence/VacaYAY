using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccesLayer.Entities.Enums;

namespace BusinessLogicLayer.Dto.PositionDto
{
    public record PositionDto
    {
        public int Id { get; init; }
        public PositionCaption Caption { get; set; }
        public string Description { get; set; }
    }
}
