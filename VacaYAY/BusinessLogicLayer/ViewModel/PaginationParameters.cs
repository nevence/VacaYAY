using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccesLayer.Entities.Enums;

namespace BusinessLogicLayer.ViewModel
{
    public class PaginationParameters
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public string SearchTerm { get; set; }
        public bool HasPrevious {  get; set; }
        public bool HasNext { get; set; }
        public VacationRequestLeaveType LeaveType { get; set; }
        public VacationRequestStatus Status { get; set; }
        public PositionCaption Caption { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
    }
}
