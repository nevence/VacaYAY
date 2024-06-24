using BusinessLogicLayer.Dto.EmployeeDto;
using BusinessLogicLayer.Dto.PositionDto;
using BusinessLogicLayer.ViewModel;
using DataAccesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Extensions
{
   public static class PositionExtension
    {
        public static PositionDto MapToPositionDto(this Position position)
        {
            return new PositionDto
            {
                Id = position.Id,
                Caption = position.Caption,
                Description = position.Description,
            };
        }

        public static IEnumerable<PositionDto> MapToPositionsDto(this IEnumerable<Position> positions)
        {
            return positions.Select(position => position.MapToPositionDto());
        }

        public static Position MapToPositionCreation(this PositionForCreationDto positionForCreation)
        {
            return new Position
            {
                Caption = positionForCreation.Caption,
                Description = positionForCreation.Description
            };
        }

        public static void MapToPositionUpdate(this Position position, PositionForUpdateDto positionForUpdate)
        {
            position.Caption = positionForUpdate.Caption;
            position.Description = positionForUpdate.Description;
            position.UpdateDate = DateTime.UtcNow;

        }

        public static PositionDropdownViewModel MapToPositionDropdown(this Position position)
        {
            return new PositionDropdownViewModel
            {
                Caption = position.Caption,
                Id = position.Id,
            };
        }

        public static List<PositionDropdownViewModel> MapToPositionsDropdown(this IEnumerable<Position> positions)
        {
            return positions.Select(position => position.MapToPositionDropdown()).ToList();
        }
    }
}
