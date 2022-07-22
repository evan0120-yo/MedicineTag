using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicineTag.Models;

// https://docs.microsoft.com/zh-tw/dotnet/api/system.componentmodel.dataannotations?view=net-6.0 完整命名清單
public class MedicineInfo
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid id{ get; set; }

    [Required]
    public string name{get;set;} = string.Empty;  // 藥物名稱

    // public virtual ICollection<MedicineInfo> medicineInfos{get;set;}
}
