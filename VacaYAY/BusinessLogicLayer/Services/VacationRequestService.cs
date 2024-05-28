using BusinessLogicLayer.Contracts;
using BusinessLogicLayer.Dto.VacationRequestDto;
using BusinessLogicLayer.Exceptions;
using BusinessLogicLayer.Extensions;
using BusinessLogicLayer.ViewModel;
using DataAccesLayer.Contracts;
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

        public async Task<int> CreateVacationRequestAsync(VacationRequestForCreationDto vacationRequestForCreation)
        {


            var vacationRequestEntity = vacationRequestForCreation.MapToVacationRequestCreation();
            _repository.VacationRequest.Create(vacationRequestEntity);
            await _repository.SaveAsync();
            
            return vacationRequestEntity.Id;
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
            var vacationRequestEntity = await _repository.VacationRequest.FindByCondition(v => v.Id.Equals(id), false).SingleOrDefaultAsync();
            Guard.ThrowIfNotFound(vacationRequestEntity, id);

            var vacationRequestDto = vacationRequestEntity.MapToVacationRequestDto();
            return vacationRequestDto;
        }

        public async Task<DtoViewModel<VacationRequestDto>> GetVacationRequestsAsync(RequestParameters requestParameters)
        {
            var result = await _repository.VacationRequest.GetAllAsync(requestParameters.PageNumber, requestParameters.PageSize);    

            var vacationRequestsDto = result.entities.MapToVacationRequestsDto();
            var vacationRequestsViewModel = new DtoViewModel<VacationRequestDto>(vacationRequestsDto, result.count, requestParameters.PageNumber, requestParameters.PageSize);

            return vacationRequestsViewModel;
        }

        public async Task<DtoViewModel<VacationRequestDto>> GetVacationRequestsForEmployeeAsync(RequestParameters requestParameters, int employeeId)
        {
            var result = await _repository.VacationRequest.GetAllByConditionAsync(requestParameters.PageNumber, requestParameters.PageSize, employeeId);

            var vacationRequestsDto = result.entities.MapToVacationRequestsDto();
            var vacationRequestsViewModel = new DtoViewModel<VacationRequestDto>(vacationRequestsDto, result.count, requestParameters.PageNumber, requestParameters.PageSize);

            return vacationRequestsViewModel;
        }

        public async Task UpdateVacationRequestAsync(int id, VacationRequestForUpdateDto vacationRequestForUpdate)
        {
            var vacationRequestEntity = await _repository.VacationRequest.FindByCondition(v => v.Id.Equals(id), true).SingleOrDefaultAsync();
            Guard.ThrowIfNotFound(vacationRequestEntity, id);

            vacationRequestEntity.MapToVacationRequestUpdate(vacationRequestForUpdate);

            await _repository.SaveAsync();
        }
    }
}
