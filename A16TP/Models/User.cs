using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace A16TP.Models
{
    public class User
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("name")]
        [StringLength(255)]
        public string? Name { get; set; }

        [Required]
        [Column("familyName")]
        [StringLength(255)]
        public string FamilyName { get; set; } = string.Empty;

        [Required]
        [Column("tel")]
        [StringLength(20)]
        public string Tel { get; set; } = string.Empty;

        [Required]
        [Column("email")]
        [StringLength(255)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        // Navigation properties
        public ICollection<Basket> Baskets { get; set; } = new List<Basket>();
    }
}