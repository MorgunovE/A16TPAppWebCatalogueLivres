using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace A16TP.Models
{
    [Table("Basket_Livre")]
    public class BasketBook
    {
        [Column("basket_id")]
        [Display(Name = "Basket")]
        public long BasketId { get; set; }

        [Column("livre_id")]
        [Display(Name = "Book")]
        public long BookId { get; set; }

        [ForeignKey("BasketId")]
        public Basket? Basket { get; set; }

        [ForeignKey("BookId")]
        public Book? Book { get; set; }
    }
}