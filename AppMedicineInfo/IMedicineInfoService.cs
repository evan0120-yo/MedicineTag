namespace MedicineTag.AppMedicineInfo;


public interface IMedicineInfoService
{
    public void Add(MedicineInfo medicineInfo);

    public void Delete(Guid id);

    public void Update(MedicineInfo medicineInfo);

    public MedicineInfo GetOne(Guid id);

    public IEnumerable<MedicineInfo> GetAll();
}

