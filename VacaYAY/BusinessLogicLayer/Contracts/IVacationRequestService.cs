using BusinessLogicLayer.Dto.PositionDto;
using BusinessLogicLayer.Dto.VacationRequestDto;
using DataAccesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Contracts
{
    public interface IVacationRequestService
    {
        Task<VacationRequestDto> GetVacationRequestAsync(int id);
        Task<IEnumerable<VacationRequestDto>> GetVacationRequestsAsync(int employeeId);
        Task<int> CreateVacationRequestAsync(VacationRequestForCreationDto vacationRequestForCreation);
        Task UpdateVacationRequestAsync(int id, VacationRequestForUpdateDto vacationRequestForUpdate);
        Task DeleteVacationRequestAsync(int id);
    }
}
