using ApiPW.Models;
using ApiPW.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiPW.Services
{
    public interface IEquipmentService
    {
        Task<ApiResponse<IEnumerable<EquipmentDto>>> GetAllEquipmentAsync();
        Task<ApiResponse<EquipmentDto>> GetEquipmentByIdAsync(int id);
        Task<ApiResponse<EquipmentDto>> CreateEquipmentAsync(CreateEquipmentDto createDto);
        Task<ApiResponse<EquipmentDto>> UpdateEquipmentAsync(int id, UpdateEquipmentDto updateDto);
        Task<ApiResponse<bool>> DeleteEquipmentAsync(int id);
        Task<ApiResponse<IEnumerable<EquipmentDto>>> GetEquipmentByStatusAsync(EquipmentStatus status);
    }
}