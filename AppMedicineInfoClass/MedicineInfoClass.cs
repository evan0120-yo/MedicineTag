using MedicineTag.AppMedicineClass;
using MedicineTag.AppMedicineInfo;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicineTag.AppMedicineInfoClass;

public class MedicineInfoClass
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid MedicineInfoClassId { get; set; }

    public Guid MedicineInfoId { get; set; }

    public Guid MedicineClassId { get; set; }

    public MedicineInfo? MedicineInfo { get; set; }

    public MedicineClass? MedicineClass { get; set; }

}
