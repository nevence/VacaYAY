using Azure.Core;
using BusinessLogicLayer.Contracts;
using BusinessLogicLayer.Dto.VacationRequestDto;
using BusinessLogicLayer.Exceptions;
using BusinessLogicLayer.Extensions;
using BusinessLogicLayer.ViewModel;
using DataAccesLayer.Contracts;
using DataAccesLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public sealed class VacationRequestService : IVacationRequestService
    {

        private readonly IRepositoryManager _repository;

        public VacationRequestService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task CreateVacationRequestAsync(VacationRequestForCreationDto vacationRequestForCreation)
        {
            var vacationRequestEntity = vacationRequestForCreation.MapToVacationRequestCreation();
            Guard.ThrowIfInvalidLeaveDate(vacationRequestEntity);

            _repository.VacationRequest.Create(vacationRequestEntity);

            await _repository.SaveAsync();
        }

        public async Task DeleteVacationRequestAsync(int id)
        {
            var vacationRequestEntity = await _repository.VacationRequest.FindByCondition(v => v.Id.Equals(id), true).SingleOrDefaultAsync();
            Guard.ThrowIfNotFound(vacationRequestEntity, id);

            _repository.VacationRequest.Delete(vacationRequestEntity);
            await _repository.SaveAsync();
        }

        public async Task<VacationRequestDto> GetVacationRequestAsync(int id)
        {
            var vacationRequestEntity = await _repository.VacationRequest.FindByCondition(v => v.Id.Equals(id), false).Include(v => v.Employee).SingleOrDefaultAsync();
            Guard.ThrowIfNotFound(vacationRequestEntity, id);

            var vacationRequestDto = vacationRequestEntity.MapToVacationRequestDto();
            return vacationRequestDto;
        }

        public async Task<PaginatedResponse<VacationRequestDto>> GetVacationRequestsAsync(RequestParameters requestParameters)
        {
            var result = await _repository.VacationRequest.GetAllVacationRequestsAsync(requestParameters.PageNumber, requestParameters.PageSize, requestParameters.SearchTerm, requestParameters.LeaveType, requestParameters.Status);    

            var vacationRequestsDto = result.entities.MapToVacationRequestsDto();
            var vacationRequestsViewModel = new PaginatedResponse<VacationRequestDto>(vacationRequestsDto, result.count, requestParameters);

            return vacationRequestsViewModel;
        }

        public async Task<PaginatedResponse<VacationRequestDto>> GetVacationRequestsForEmployeeAsync(RequestParameters requestParameters, int employeeId)
        {
            var result = await _repository.VacationRequest.GetAllVacationRequestsForEmployeeAsync(requestParameters.PageNumber, requestParameters.PageSize, employeeId, requestParameters.LeaveType, requestParameters.Status);

            var vacationRequestsDto = result.entities.MapToVacationRequestsDto();
            var vacationRequestsViewModel = new PaginatedResponse<VacationRequestDto>(vacationRequestsDto, result.count, requestParameters);

            return vacationRequestsViewModel;
        }

        public async Task UpdateVacationRequestAsync(int id, VacationRequestForUpdateDto vacationRequestForUpdate)
        {
            var vacationRequestEntity = await _repository.VacationRequest.FindByCondition(v => v.Id.Equals(id), true).Include(v => v.Employee).SingleOrDefaultAsync();
            Guard.ThrowIfNotFound(vacationRequestEntity, id);

            vacationRequestEntity.MapToVacationRequestUpdate(vacationRequestForUpdate);
            Guard.ThrowIfInvalidLeaveDate(vacationRequestEntity);

            await _repository.SaveAsync();
        }

        public async Task RejectVacationRequestAsync(int id)
        {
            var vacationRequestEntity = await _repository.VacationRequest.FindByCondition(v => v.Id.Equals(id), true).Include(v => v.Employee).SingleOrDefaultAsync();
            Guard.ThrowIfNotFound(vacationRequestEntity, id);
            Guard.ThrowIfRequestProcessed(vacationRequestEntity);

            vacationRequestEntity.MapVacationRequestReject();

            await _repository.SaveAsync();
        }

        public async Task ApproveVacationRequestAsync(int id)
        {
            var vacationRequestEntity = await _repository.VacationRequest.FindByCondition(v => v.Id.Equals(id), true).Include(v => v.Employee).SingleOrDefaultAsync();
            Guard.ThrowIfNotFound(vacationRequestEntity, id);
            Guard.ThrowIfInsufficentDaysOff(vacationRequestEntity);
            Guard.ThrowIfRequestProcessed(vacationRequestEntity);

            vacationRequestEntity.MapVacationRequestApprove();

            await _repository.SaveAsync();
        }
    }
}
