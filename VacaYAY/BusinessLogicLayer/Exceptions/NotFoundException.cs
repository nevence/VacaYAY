using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(int Id) : base($"Entity with Id {Id} was not found.")
        {

        }

    }
}
