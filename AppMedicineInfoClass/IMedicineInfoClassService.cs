namespace MedicineTag.AppMedicineInfoClass;

public interface IMedicineInfoClassService
{
    public void Add(MedicineInfoClass medicineInfoClass);

    public void Delete(Guid id);

    public void Update(MedicineInfoClass medicineInfoClass);

    public MedicineInfoClass GetOne(Guid id);

    public IEnumerable<MedicineInfoClass> GetAll();
}
