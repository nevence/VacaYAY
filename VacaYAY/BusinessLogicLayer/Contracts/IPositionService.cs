using BusinessLogicLayer.Dto.PositionDto;
using BusinessLogicLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Contracts
{
    public interface IPositionService
    {
        Task<PositionDto> GetPositionAsync(int id);
        Task<PaginatedResponse<PositionDto>> GetPositionsAsync(RequestParameters requestParameters);
        Task<int> CreatePositionAsync(PositionForCreationDto positionForUpdate);
        Task UpdatePositionAsync(int id, PositionForUpdateDto positionForUpdate);
        Task DeletePositionAsync(int id);
    }
}
