using SmartWork.Core.DTOs.EquipmentDTOs;
using System.Threading.Tasks;

namespace SmartWork.Core.Abstractions.Services
{
    public interface IEquipmentService
    {
        Task<bool> AddEquipmentForRoom(AddEquipmentDTO equipmentDTO);
        Task<bool> DeleteEquipment(int equipmentId);
        Task<bool> UpdateEquipmentForRoom(UpdateEquipmentDTO equipmentDTO);
    }
}
