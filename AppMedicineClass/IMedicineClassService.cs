namespace MedicineTag.AppMedicineClass;

public interface IMedicineClassService
{
    public void Add(MedicineClass medicineClass);

    public void Delete(Guid id);

    public void Update(MedicineClass medicineClass);

    public MedicineClass GetOne(Guid id);

    public IEnumerable<MedicineClass> GetAll();
}
