using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS55
{
    [Table("Category55")]
    public class Category55
    {
        [Key]
        public int CategoryId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        public virtual List <Product55> Products { get; set; }
    }
}