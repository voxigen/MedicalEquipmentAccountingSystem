using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ApiPW.Data;
using ApiPW.Models;
using ApiPW.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace ApiPW.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EquipmentService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<EquipmentDto>>> GetAllEquipmentAsync()
        {
            try
            {
                var equipment = await _context.Equipment
                    .Include(e => e.Department)
                    .Include(e => e.EquipmentType)
                    .ToListAsync();

                var equipmentDtos = _mapper.Map<IEnumerable<EquipmentDto>>(equipment);

                return new ApiResponse<IEnumerable<EquipmentDto>>
                {
                    Success = true,
                    Data = equipmentDtos
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<EquipmentDto>>
                {
                    Success = false,
                    Message = "Ошибка при получении оборудования",
                    Error = ex.Message
                };
            }
        }

        public async Task<ApiResponse<EquipmentDto>> GetEquipmentByIdAsync(int id)
        {
            try
            {
                var equipment = await _context.Equipment
                    .Include(e => e.Department)
                    .Include(e => e.EquipmentType)
                    .FirstOrDefaultAsync(e => e.Id == id);

                if (equipment == null)
                {
                    return new ApiResponse<EquipmentDto>
                    {
                        Success = false,
                        Message = "Оборудование не найдено"
                    };
                }

                var equipmentDto = _mapper.Map<EquipmentDto>(equipment);

                return new ApiResponse<EquipmentDto>
                {
                    Success = true,
                    Data = equipmentDto
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<EquipmentDto>
                {
                    Success = false,
                    Message = "Ошибка при получении оборудования",
                    Error = ex.Message
                };
            }
        }

        public async Task<ApiResponse<EquipmentDto>> CreateEquipmentAsync(CreateEquipmentDto createDto)
        {
            try
            {
                var exists = await _context.Equipment
                    .AnyAsync(e => e.SerialNumber == createDto.SerialNumber);

                if (exists)
                {
                    return new ApiResponse<EquipmentDto>
                    {
                        Success = false,
                        Message = "Оборудование с таким серийным номером уже существует"
                    };
                }

                var equipment = _mapper.Map<Equipment>(createDto);
                _context.Equipment.Add(equipment);
                await _context.SaveChangesAsync();

                var equipmentDto = _mapper.Map<EquipmentDto>(equipment);

                return new ApiResponse<EquipmentDto>
                {
                    Success = true,
                    Data = equipmentDto,
                    Message = "Оборудование создано успешно"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<EquipmentDto>
                {
                    Success = false,
                    Message = "Ошибка при создании оборудования",
                    Error = ex.Message
                };
            }
        }

        public async Task<ApiResponse<EquipmentDto>> UpdateEquipmentAsync(int id, UpdateEquipmentDto updateDto)
        {
            try
            {
                var equipment = await _context.Equipment
                    .Include(e => e.Department)
                    .Include(e => e.EquipmentType)
                    .FirstOrDefaultAsync(e => e.Id == id);

                if (equipment == null)
                {
                    return new ApiResponse<EquipmentDto>
                    {
                        Success = false,
                        Message = "Оборудование не найдено"
                    };
                }

                if (!string.IsNullOrEmpty(updateDto.SerialNumber) &&
                    updateDto.SerialNumber != equipment.SerialNumber)
                {
                    var exists = await _context.Equipment
                        .AnyAsync(e => e.SerialNumber == updateDto.SerialNumber);

                    if (exists)
                    {
                        return new ApiResponse<EquipmentDto>
                        {
                            Success = false,
                            Message = "Оборудование с таким серийным номером уже существует"
                        };
                    }
                }

                _mapper.Map(updateDto, equipment);
                await _context.SaveChangesAsync();

                var equipmentDto = _mapper.Map<EquipmentDto>(equipment);

                return new ApiResponse<EquipmentDto>
                {
                    Success = true,
                    Data = equipmentDto,
                    Message = "Оборудование обновлено успешно"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<EquipmentDto>
                {
                    Success = false,
                    Message = "Ошибка при обновлении оборудования",
                    Error = ex.Message
                };
            }
        }

        public async Task<ApiResponse<bool>> DeleteEquipmentAsync(int id)
        {
            try
            {
                var equipment = await _context.Equipment.FindAsync(id);
                if (equipment == null)
                {
                    return new ApiResponse<bool>
                    {
                        Success = false,
                        Message = "Оборудование не найдено"
                    };
                }

                _context.Equipment.Remove(equipment);
                await _context.SaveChangesAsync();

                return new ApiResponse<bool>
                {
                    Success = true,
                    Data = true,
                    Message = "Оборудование удалено успешно"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Message = "Ошибка при удалении оборудования",
                    Error = ex.Message
                };
            }
        }

        public async Task<ApiResponse<IEnumerable<EquipmentDto>>> GetEquipmentByStatusAsync(EquipmentStatus status)
        {
            try
            {
                var equipment = await _context.Equipment
                    .Include(e => e.Department)
                    .Include(e => e.EquipmentType)
                    .Where(e => e.Status == status)
                    .ToListAsync();

                var equipmentDtos = _mapper.Map<IEnumerable<EquipmentDto>>(equipment);

                return new ApiResponse<IEnumerable<EquipmentDto>>
                {
                    Success = true,
                    Data = equipmentDtos
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<EquipmentDto>>
                {
                    Success = false,
                    Message = "Ошибка при получении оборудования",
                    Error = ex.Message
                };
            }
        }
    }
}