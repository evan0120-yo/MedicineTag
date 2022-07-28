using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicineTag.AppMedicineInfoClass;

public class MedicineInfoClass
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public Guid MedicineInfoId { get; set; }

    public Guid MedicineClassId { get; set; }
}
