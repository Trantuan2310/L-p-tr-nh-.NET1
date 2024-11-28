using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS57
{
    public class Tag
    {
        //[Key]
        //[StringLength(20)]
        //public string TagId { set; get; }
        [Column(TypeName = "ntext")]
        public string Content { set; get; }
        
        [Key]

        public int TagId { get; set; }
    }
}