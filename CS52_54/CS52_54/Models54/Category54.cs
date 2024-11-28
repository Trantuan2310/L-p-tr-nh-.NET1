using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS54
{
    [Table("Category54")]
    public class Category54
    {
        [Key]
        public int CategoryId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        public virtual List <Product54> Products { get; set; }
    }
}