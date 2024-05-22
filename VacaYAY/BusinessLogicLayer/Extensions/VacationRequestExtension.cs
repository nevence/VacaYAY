using BusinessLogicLayer.Dto.PositionDto;
using BusinessLogicLayer.Dto.VacationRequestDto;
using DataAccesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Extensions
{
    public static class VacationRequestExtensions
    {
        public static VacationRequestDto MapToVacationRequestDto(this VacationRequest vacationRequest)
        {
            return new VacationRequestDto
            {
                EmployeeId = vacationRequest.EmployeeId,
                FullName = string.Join(' ', vacationRequest.Employee.FirstName, vacationRequest.Employee.LastName).Trim(),
                StartDate = vacationRequest.StartDate,
                EndDate = vacationRequest.EndDate,
                Status = vacationRequest.Status,
                LeaveType = vacationRequest.LeaveType,
                HRComment = vacationRequest.HRComment,  
                EmployeeComment = vacationRequest.EmployeeComment,
                RequestDate = vacationRequest.RequestDate
            };
        }

        public static IEnumerable<VacationRequestDto> MapToVacationRequestsDto(this IEnumerable<VacationRequest> vacationRequests)
        {
            return vacationRequests.Select(vacationRequest => vacationRequest.MapToVacationRequestDto());
        }

        public static VacationRequest MapToVacationRequestCreation(this VacationRequestForCreationDto vacationRequestForCreation)
        {
            return new VacationRequest
            {
                EmployeeId = vacationRequestForCreation.EmployeeId,
                StartDate = vacationRequestForCreation.StartDate,
                EndDate = vacationRequestForCreation.EndDate,
                Status = vacationRequestForCreation.Status,
                LeaveType = vacationRequestForCreation.LeaveType,
                HRComment = vacationRequestForCreation.HRComment,
                EmployeeComment = vacationRequestForCreation.EmployeeComment,
                RequestDate = vacationRequestForCreation.RequestDate,
            };
        }

        public static void MapToVacationRequestUpdate(this VacationRequest vacationRequest, VacationRequestForUpdateDto vacationRequestForUpdate)
        {
            vacationRequest.Status = vacationRequestForUpdate.Status;
            vacationRequest.LeaveType = vacationRequestForUpdate.LeaveType;
            vacationRequest.HRComment = vacationRequestForUpdate.HRComment;
            vacationRequest.EmployeeComment = vacationRequestForUpdate.EmployeeComment; 
            vacationRequest.UpdateDate = DateTime.UtcNow;

        }
    }
   
}
