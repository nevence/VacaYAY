﻿using BusinessLogicLayer.Contracts;
using BusinessLogicLayer.Dto.PositionDto;
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
    public sealed class PositionService : IPositionService
    { 
        private readonly IRepositoryManager _repository;

        public PositionService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task<int> CreatePositionAsync(PositionForCreationDto positionForUpdate)
        {
            var positionEntity = positionForUpdate.MapToPositionCreation();
            _repository.Position.Create(positionEntity);
            await _repository.SaveAsync();

            return positionEntity.Id;
        }

        public async Task DeletePositionAsync(int id)
        {
            var positionEntity = await _repository.Position.FindByCondition(v => v.Id.Equals(id), true).SingleOrDefaultAsync();
            Guard.ThrowIfNotFound(positionEntity, id);

            _repository.Position.Delete(positionEntity);
            await _repository.SaveAsync();
        }

        public async Task<PositionDto> GetPositionAsync(int id)
        {
            var positionEntity = await _repository.Position.FindByCondition(v => v.Id.Equals(id), false).SingleOrDefaultAsync();
            Guard.ThrowIfNotFound(positionEntity, id);

            var positionDto = positionEntity.MapToPositionDto();
            return positionDto;
        }

        public async Task<PaginatedResponse<PositionDto>> GetPositionsAsync(RequestParameters requestParameters)
        {
            var result = await _repository.Position.GetAllPoitionsAsync(requestParameters.PageNumber, requestParameters.PageSize, requestParameters.SearchTerm, requestParameters.Caption);

            var positionsDto = result.entities.MapToPositionsDto();
            var positionsViewModel = new PaginatedResponse<PositionDto>(positionsDto, result.count, requestParameters);

            return positionsViewModel;
        }

        public async Task<List<PositionDropdownViewModel>> GetPositionsForDropdownAsync()
        {
            var result = await _repository.Position.FindAll(false).ToListAsync();
            var positonsDropdown = result.MapToPositionsDropdown();

            return positonsDropdown;
        }

        public async Task UpdatePositionAsync(int id, PositionForUpdateDto positionForUpdate)
        {
            var positionEntity = await _repository.Position.FindByCondition(v => v.Id.Equals(id), true).SingleOrDefaultAsync();
            Guard.ThrowIfNotFound(positionEntity, id);

            positionEntity.MapToPositionUpdate(positionForUpdate);

            await _repository.SaveAsync();  
        }
    }
}
