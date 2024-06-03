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
    }

}
