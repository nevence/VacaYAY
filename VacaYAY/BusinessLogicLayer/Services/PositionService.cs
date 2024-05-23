using BusinessLogicLayer.Contracts;
using BusinessLogicLayer.Dto.PositionDto;
using BusinessLogicLayer.Exceptions;
using BusinessLogicLayer.Extensions;
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
            var positionEntity = await _repository.Position.FindAll(true).SingleOrDefaultAsync(v => v.Id.Equals(id));
            Guard.ThrowIfNotFound(positionEntity, id);

            _repository.Position.Delete(positionEntity);
            await _repository.SaveAsync();
        }

        public async Task<PositionDto> GetPositionAsync(int id)
        {
            var positionEntity = await _repository.Position.FindAll(false).SingleOrDefaultAsync(v => v.Id.Equals(id));
            Guard.ThrowIfNotFound(positionEntity, id);

            var positionDto = positionEntity.MapToPositionDto();
            return positionDto;
        }

        public async Task<IEnumerable<PositionDto>> GetPositionsAsync()
        {
            var positionsEntity = await _repository.Position.FindAll(false).ToListAsync();

            var positionsDto = positionsEntity.MapToPositionsDto();
            return positionsDto;
        }

        public async Task UpdatePositionAsync(int id, PositionForUpdateDto positionForUpdate)
        {
            var positionEntity = await _repository.Position.FindAll(true).SingleOrDefaultAsync(v => v.Id.Equals(id));
            Guard.ThrowIfNotFound(positionEntity, id);

            positionEntity.MapToPositionUpdate(positionForUpdate);

            await _repository.SaveAsync();  
        }
    }
}
