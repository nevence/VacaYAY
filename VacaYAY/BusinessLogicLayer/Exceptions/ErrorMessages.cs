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
    }

}
