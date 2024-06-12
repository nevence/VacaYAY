using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ViewModel
{
    public record AdminDashboardViewModel
    {
        public int TotalEmployees { get; init; }
        public int TotalVacationRequests { get; init; }
        public int PendingVacationRequests { get; init; }
    }
}
