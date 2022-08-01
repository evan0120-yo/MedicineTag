using MedicineTag.AppException;
using MedicineTag.Models;

namespace MedicineTag.AppMedicineClass;

public class MedicineClassService : IMedicineClassService
{
    private readonly MedicineContext _medicineContext;
    private readonly ILogger<IMedicineClassService> _logger; 

    public MedicineClassService(MedicineContext medicineContext, ILogger<IMedicineClassService> logger)
    {
        _medicineContext = medicineContext;
        _logger = logger;
    }

    public void Add(MedicineClass medicineClass)
    {
        try
        {
            _medicineContext.Add(medicineClass);
            // 此時 EntityState = Add = add
            _medicineContext.SaveChanges();
        }
        catch (Exception e)
        {
            _logger.LogError(e.ToString());
            throw new DataBaseException("資料庫發生問題");
        }
    }

    public void Delete(Guid id)
    {
        // 1
        //var medicineInfo = _medicineContext.medicineInfos.Find(id);
        // 2
        var medicineClass = (from a in _medicineContext.medicineClass
                            where a.MedicineClassId == id
                            select a).SingleOrDefault();

        if (medicineClass == null)
        {
            throw new DataNotFoundException("該id查無此資料");
        }
        try
        {
            _medicineContext.medicineClass.Remove(medicineClass);
            // 此時 EntityState = Deleted = delete
            _medicineContext.SaveChanges();
        }
        catch (Exception e)
        {
            _logger.LogError(e.ToString());
            throw new DataBaseException("資料庫發生問題");
        }
    }

    public void Update(MedicineClass medicineClass)
    {
        var resault = (from a in _medicineContext.medicineClass
                       where a.MedicineClassId == medicineClass.MedicineClassId
                       select a).SingleOrDefault();
        // 此時 EntityState = Modified = update
        if (resault == null)
        {
            throw new DataNotFoundException("該id查無此資料");
        }

        try
        {
            resault.MedicineClassName = medicineClass.MedicineClassName;
            _medicineContext.SaveChanges();
        }
        catch (Exception e)
        {
            _logger.LogError(e.ToString());
            throw new DataBaseException("資料庫發生問題");
        }
    }

    public MedicineClass GetOne(Guid id)
    {
        // === 1 ===
        // var medicineInfo = _medicineContext.medicineInfos.Find(id);
        // === 2 ===
        var medicineClass = (from a in _medicineContext.medicineClass
                            where a.MedicineClassId == id
                            select a).SingleOrDefault();
        // === 3 ===
        //var medicineInfo = _medicineContext.medicineInfos
        //    .FromSqlRaw($"select * from medicineinfos where id = '{id}'").SingleOrDefault();
        if (medicineClass == null)
        {
            throw new DataNotFoundException("查無此id");
        }
        return medicineClass;
    }
    public IEnumerable<MedicineClass> GetAll()
    {
        // 1
        //var medicineinfolist = _medicineContext.medicineInfos;
        // 2
        var medicineClassList = (from a in _medicineContext.medicineClass
                                select a).ToList();
        // 3
        //var medicineInfoList = _medicineContext.medicineInfos
        //    .FromSqlRaw("select * from medicineinfos")
        //    .ToList(); 

        return medicineClassList;
    }
}
