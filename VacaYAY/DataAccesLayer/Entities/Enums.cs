using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Entities
{
    public static class Enums
    {
        public enum PositionCaption
        {
            ITAdministrator,
            SalesExecutive,
            ProcurementOfficer,
            HRManager,
        }

        public enum VacationRequestStatus
        {
            Pending,
            Accepted,
            Rejected
        }

        public enum VacationRequestLeaveType
        {
            SickLeave,
            MaternityLeave,
            CasualLeave,
            AnnualLeave
        }

        public enum Roles
        {
            HR,
            Employee
        }
    }
}
