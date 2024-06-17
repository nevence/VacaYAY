using DataAccesLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Exceptions
{
    public static class Guard
    {
        public static void ThrowIfNotFound(object obj, int id)
        {
            if (obj == null)
            {
                throw new KeyNotFoundException(string.Format(ErrorMessages.EntityNotFound, id));
            }
        }

        public static void ThrowIfNotFoundString(object obj)
        {
            if (obj == null)
            {
                throw new KeyNotFoundException(string.Format(ErrorMessages.EntityNotFoundString));
            }
        }


        public static void ThrowIfFailedIdentity(IdentityResult result)
        {
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException(errors);
            }
        }

        public static void ThrowIfInsufficentDaysOff(VacationRequest request)
        {
            var requestDays = GetWorkingDays(request.StartDate, request.EndDate);
            if (requestDays > request.Employee.DaysOffNumber)
            {
                throw new ArgumentException(ErrorMessages.InsufficentDaysOff);
            }
        }

        private static int GetWorkingDays(DateTime start, DateTime end)
        {
            int totalDays = 0;
            DateTime current = start;

            while (current <= end)
            {
                if (current.DayOfWeek != DayOfWeek.Saturday && current.DayOfWeek != DayOfWeek.Sunday)
                {
                    totalDays++;
                }
                current = current.AddDays(1);
            }

            return totalDays;
        }
    }
}
