using System.ComponentModel.DataAnnotations;

namespace MedicineTag.AppMedicineInfo;

public class MedicineInfoVO
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public DateTime UpdateTime { get; set; } = DateTime.Now;

    public DateTime CreateTime { get; set; } = DateTime.Now;
}