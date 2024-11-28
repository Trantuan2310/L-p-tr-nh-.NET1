using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS53
{
    [Table("Category53")]
    public class Category53
    {
        [Key]
        public int CategoryId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        public virtual List <Product53> Products { get; set; }
    }
}