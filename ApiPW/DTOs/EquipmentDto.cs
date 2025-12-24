using System;

namespace ApiPW.Models.DTOs
{
    public class EquipmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime PurchaseDate { get; set; }
        public decimal PurchasePrice { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public string EquipmentTypeName { get; set; } = string.Empty;
    }

    public class CreateEquipmentDto
    {
        public string Name { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;
        public EquipmentStatus Status { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PurchasePrice { get; set; }
        public int DepartmentId { get; set; }
        public int EquipmentTypeId { get; set; }
    }

    public class UpdateEquipmentDto
    {
        public string? Name { get; set; }
        public string? SerialNumber { get; set; }
        public EquipmentStatus? Status { get; set; }
        public int? DepartmentId { get; set; }
    }
}