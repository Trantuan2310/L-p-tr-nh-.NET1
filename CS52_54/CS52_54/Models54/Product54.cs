using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS54
{
    //[Table("Product54")]
    public class Product54
    {
        //[Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(50)]
        [Column("Tensanpham", TypeName = "ntext")]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int? CateId {  get; set; }
        // Foreign Key
        //[ForeignKey("CateId")]
        //[Required]
        public virtual Category54 Category54 { get; set; }

        public int? CateId02 { get; set; }
        //[ForeignKey("CateId02")]
        //[InverseProperty("Products")]
        public virtual Category54 Category5402 { get; set; }

        public void PrintInfo() => Console.WriteLine($"{ProductId} - {Name} - {Price}");
    }
}