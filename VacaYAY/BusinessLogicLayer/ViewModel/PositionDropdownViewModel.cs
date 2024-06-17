using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccesLayer.Entities.Enums;

namespace BusinessLogicLayer.ViewModel
{
    public record PositionDropdownViewModel
    {
        public int Id {  get; init; }
        public PositionCaption Caption { get; init; }
    }
}
