using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Exceptions
{
    public static class SuccessMessages
    {
        public const string SuccessMessage = "SuccessMessage";

        public const string EmployeeLogin = "Successfully logged in.";
        public const string EmployeeRegister = "Sucessfully added a new employee";
        public const string RequestCreate = "Succesfully created a new leave request";
        public const string RequestApprove = "Sucessfully approved a leave request";
        public const string RequestReject = "Sucessfully rejected a leave request";
        public const string Edit = "Sucessfully edited.";
        public const string Delete = "Sucessfully deleted.";
        public const string MigrateEmployees = "Successfully loaded old employees into the database.";
        public const string PositionCreate = "Succesfully added a new position";
    }
}
