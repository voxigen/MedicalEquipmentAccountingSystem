using System.ComponentModel.DataAnnotations;

namespace ApiPW.Models
{
    public class EquipmentType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        public ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();
    }
}