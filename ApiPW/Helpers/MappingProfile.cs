using ApiPW.Models;
using ApiPW.Models.DTOs;
using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApiPW.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Equipment, EquipmentDto>()
                .ForMember(dest => dest.DepartmentName,
                    opt => opt.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.EquipmentTypeName,
                    opt => opt.MapFrom(src => src.EquipmentType.Name))
                .ForMember(dest => dest.Status,
                    opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<CreateEquipmentDto, Equipment>();
            CreateMap<UpdateEquipmentDto, Equipment>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Department, DepartmentDto>()
                .ForMember(dest => dest.EquipmentCount,
                    opt => opt.MapFrom(src => src.Equipment.Count));

            CreateMap<CreateDepartmentDto, Department>();

            CreateMap<MaintenanceRecord, MaintenanceRecordDto>()
                .ForMember(dest => dest.EquipmentName,
                    opt => opt.MapFrom(src => src.Equipment.Name))
                .ForMember(dest => dest.MaintenanceType,
                    opt => opt.MapFrom(src => src.MaintenanceType.ToString()));

            CreateMap<CreateMaintenanceRecordDto, MaintenanceRecord>();
        }
    }
}