using System.ComponentModel.DataAnnotations;

namespace MedicineTag.AppMedicineInfo;

public class MedicineInfoVO
{
    public Guid MedicineInfoId { get; set; }

    public string? MedicineInfoName { get; set; }

    public DateTime UpdateTime { get; set; } = DateTime.Now;

    public DateTime CreateTime { get; set; } = DateTime.Now;
}