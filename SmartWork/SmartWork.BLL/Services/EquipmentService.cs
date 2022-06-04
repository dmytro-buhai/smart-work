using Microsoft.Extensions.Logging;
using SmartWork.Core.Abstractions.Repositories;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.DTOs.EquipmentDTOs;
using SmartWork.Core.Entities;
using SmartWork.Core.Enums;
using System;
using System.Threading.Tasks;

namespace SmartWork.BLL.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEntityRepository<Equipment> _equipmentRepository;
        private readonly ILogger<EquipmentService> _logger;

        public EquipmentService(IEntityRepository<Equipment> equipmentRepository,
            ILogger<EquipmentService> logger)
        {
            _equipmentRepository = equipmentRepository;
            _logger = logger;
        }

        public async Task<bool> AddEquipmentForRoom(AddEquipmentDTO equipmentDTO)
        {
            try
            {
                var newEquipment = new Equipment
                {
                    RoomId = equipmentDTO.RoomId,
                    Name = equipmentDTO.Name,
                    Type = (EquipmentType)equipmentDTO.Type,
                    Description = equipmentDTO.Description,
                    Amount = equipmentDTO.Amount,
                    IsAvailable = equipmentDTO.IsAvailable
                };

                await _equipmentRepository.AddAsync(newEquipment);
                await _equipmentRepository.SaveChangesAsync();

                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError($"error during adding room equipment: {ex.Message}");
                return default;
            }
        }

        public async Task<bool> UpdateEquipmentForRoom(UpdateEquipmentDTO equipmentDTO)
        {
            var currentEquipment = await _equipmentRepository.FindAsync(equipmentDTO.Id);

            if(currentEquipment == null)
            {
                _logger.LogError("there is no equipment with the specified data");
                return default;
            }

            try
            {
                currentEquipment.RoomId = equipmentDTO.RoomId;
                currentEquipment.Name = equipmentDTO.Name;
                currentEquipment.Type = (EquipmentType)equipmentDTO.Type;
                currentEquipment.Amount = equipmentDTO.Amount;
                currentEquipment.IsAvailable = equipmentDTO.IsAvailable;

                await _equipmentRepository.UpdateAsync(currentEquipment);
                await _equipmentRepository.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error during updating room equipment: {ex.Message}");
                return default;
            }
        }

        public async Task<bool> DeleteEquipment(int equipmentId)
        {
            var currentEquipment = await _equipmentRepository.FindAsync(equipmentId);

            if (currentEquipment == null)
            {
                _logger.LogError("there is no equipment with the specified data");
                return default;
            }

            try
            {
                await _equipmentRepository.RemoveAsync(currentEquipment);
                await _equipmentRepository.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error during deleting room equipment: {ex.Message}");
                return default;
            }
        }
    }
}
