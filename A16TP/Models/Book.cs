using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace A16TP.Models
{
    [Table("Livre")]
    public class Book
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("title")]
        [StringLength(255)]
        public string? Title { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("author")]
        [StringLength(255)]
        public string? Author { get; set; }

        [Column("genre")]
        [StringLength(255)]
        public string? Genre { get; set; }

        [Column("image")]
        [StringLength(255)]
        public string? Image { get; set; }

        [Column("price")]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [Column("quantity")]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        // Navigation properties
        public ICollection<BasketBook> BasketBooks { get; set; } = new List<BasketBook>();
    }
}