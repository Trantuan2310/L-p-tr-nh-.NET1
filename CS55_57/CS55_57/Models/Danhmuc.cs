using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CS55_57.Models;

[Table("Danhmuc")]
public partial class Danhmuc
{
    [Key]
    [Column("DanhmucID")]
    public int DanhmucId { get; set; }

    [StringLength(255)]
    public string? TenDanhMuc { get; set; }

    [StringLength(255)]
    public string? MoTa { get; set; }
}
