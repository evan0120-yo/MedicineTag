using MedicineTag.Models;

namespace MedicineTag.Service.Impl;


public interface IMedicineInfoService
{
    public void Add(MedicineInfo medicineInfo);

    public void Delete(Guid id);

    public void Update(MedicineInfo medicineInfo);
}

