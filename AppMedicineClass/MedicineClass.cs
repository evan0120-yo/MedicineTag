using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicineTag.AppMedicineClass;

public class MedicineClass
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid MedicineClassId { get; set; }

    public string? MedicineClassName { get; set; }   // BP

    public string? MedicineClassTpye { get; set; }   // BP的類型

}

