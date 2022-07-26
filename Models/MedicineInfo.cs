using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicineTag.Models;

public class MedicineInfo
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id{ get; set; }

    [Required]
    public string Name{get;set;} = string.Empty;  // 藥物名稱

    public DateTime UpdateTime { get; set; }

    public DateTime CreateTime { get; set; }

}
