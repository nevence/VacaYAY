﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Contracts
{
    public interface IServiceManager
    {
        IAuthService AuthService { get; }
        IPositionService PositionService { get; }   
        IVacationRequestService VacationRequestService { get; }
    }
}
