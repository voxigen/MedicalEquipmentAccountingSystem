using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPW.Models
{
    public class MaintenanceRecord
    {
        public int Id { get; set; }

        [Required]
        public int EquipmentId { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime MaintenanceDate { get; set; }

        [Required]
        public MaintenanceType MaintenanceType { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        [StringLength(100)]
        public string PerformedBy { get; set; } = string.Empty;

        [Column(TypeName = "decimal(10,2)")]
        public decimal? Cost { get; set; }

        // Навигационное свойство
        public Equipment? Equipment { get; set; }
    }

    public enum MaintenanceType
    {
        Routine,
        Repair,
        Calibration,
        Inspection
    }
}