using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPW.Models
{
    public class Equipment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string SerialNumber { get; set; } = string.Empty;

        public EquipmentStatus Status { get; set; } = EquipmentStatus.Active;

        [Column(TypeName = "date")]
        public DateTime PurchaseDate { get; set; }

        public decimal PurchasePrice { get; set; }
        public int DepartmentId { get; set; }
        public int EquipmentTypeId { get; set; }

        public Department? Department { get; set; }
        public EquipmentType? EquipmentType { get; set; }
    }

    public enum EquipmentStatus
    {
        Active,
        Maintenance,
        Inactive,
        Decommissioned
    }
}