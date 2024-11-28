using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS53
{
    [Table("Product53")]
    public class Product53
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(50)]
        [Column("Tensanpham", TypeName = "ntext")]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int CateId {  get; set; }
        // Foreign Key
        [ForeignKey("CateId")]
        //[Required]
        public virtual Category53 Category53 { get; set; }

        public int? CateId02 { get; set; }
        // Foreign Key
        [ForeignKey("CateId02")]
        [InverseProperty("Products")]
        //[Required]
        public virtual Category53 Category5302 { get; set; }

        public void PrintInfo() => Console.WriteLine($"{ProductId} - {Name} - {Price}");
    }
}