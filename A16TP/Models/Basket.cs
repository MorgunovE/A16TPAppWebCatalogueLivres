using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace A16TP.Models
{
    public class Basket
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("user_id")]
        [Display(Name = "User")]
        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        // Navigation properties
        public ICollection<BasketBook> BasketBooks { get; set; } = new List<BasketBook>();
    }
}