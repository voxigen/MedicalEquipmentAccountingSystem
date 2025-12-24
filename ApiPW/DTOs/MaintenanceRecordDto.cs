using System;

namespace ApiPW.Models.DTOs
{
    public class MaintenanceRecordDto
    {
        public int Id { get; set; }
        public string EquipmentName { get; set; } = string.Empty;
        public DateTime MaintenanceDate { get; set; }
        public string MaintenanceType { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string PerformedBy { get; set; } = string.Empty;
        public decimal? Cost { get; set; }
    }

    public class CreateMaintenanceRecordDto
    {
        public int EquipmentId { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public MaintenanceType MaintenanceType { get; set; }
        public string? Description { get; set; }
        public string PerformedBy { get; set; } = string.Empty;
        public decimal? Cost { get; set; }
    }
}