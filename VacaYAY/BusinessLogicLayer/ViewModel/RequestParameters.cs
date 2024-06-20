using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccesLayer.Entities.Enums;

namespace BusinessLogicLayer.ViewModel
{
    public class RequestParameters
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }

        public string SearchTerm { get; set; }
        public VacationRequestLeaveType LeaveType { get; set; } = VacationRequestLeaveType.None;    
        public VacationRequestStatus Status { get; set; } = VacationRequestStatus.None;
        public PositionCaption Caption { get; set; } = PositionCaption.None;
    }
}
