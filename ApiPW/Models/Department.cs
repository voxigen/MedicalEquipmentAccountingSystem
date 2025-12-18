using System.ComponentModel.DataAnnotations;

namespace ApiPW.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(200)]
        public string? Location { get; set; }

       
        public ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();
    }
}