using MedicineTag.AppMedicineInfo;

namespace MedicineTag.AppMedicineInfo.Impl;


public interface IMedicineInfoService
{
    public void Add(MedicineInfo medicineInfo);

    public void Delete(Guid id);

    public void Update(MedicineInfo medicineInfo);
}

