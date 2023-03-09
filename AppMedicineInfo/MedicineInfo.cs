using MedicineTag.AppMedicineInfoClass;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicineTag.AppMedicineInfo;


public class MedicineInfo
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid MedicineInfoId { get; set; }

    [Required]
    public string MedicineInfoName { get; set; } = string.Empty;  // 藥物名稱

    public DateTime UpdateTime { get; set; }

    public DateTime CreateTime { get; set; }

    public List<MedicineInfoClass>? MedicineInfoClassList { get; set; }

}
