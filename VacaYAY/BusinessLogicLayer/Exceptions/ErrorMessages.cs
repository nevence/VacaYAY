using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Exceptions
{
    public static class ErrorMessages
    {
        public const string EntityNotFound = "Entity with ID {0} was not found.";
        public const string InvalidLogin = "Invalid login attempt.";
        public const string RequiredField = "This field is required.";
        public const string MaxLength50 = "Maximal length of the property is 50.";
        public const string EntityNotFoundString = "Matching entity was not found.";
        public const string EmployeeMigrationError = "An error occurred while migrating employees from the old system.";
        public const string InsufficentDaysOff = "Insufficient days off available.";
        public const string Success = "Action completed successfully.";
        public const string InvalidLeaveDate = "Leave start date must come before leave end date.";
        public const string InvalidEmploymentDate = "Employment start date must come before employment end date.";
        public const string RequestProcessed = "This leave request has already been processed.";
    }

}
