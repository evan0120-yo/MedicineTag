using MedicineTag.AppException;
using MedicineTag.Models;

namespace MedicineTag.AppMedicineInfoClass;

public class MedicineInfoClassService : IMedicineInfoClassService
{
    private readonly MedicineContext _medicineContext;
    private readonly ILogger<IMedicineInfoClassService> _logger;

    public MedicineInfoClassService(MedicineContext medicineContext, ILogger<IMedicineInfoClassService> logger)
    {
        _medicineContext = medicineContext;
        _logger = logger;
    }

    public void Add(MedicineInfoClass medicineInfoClass)
    {
        try
        {
            _medicineContext.Add(medicineInfoClass);
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
        var medicineInfoClass = (from a in _medicineContext.medicineInfoClass
                                 where a.MedicineInfoClassId == id
                             select a).SingleOrDefault();

        if (medicineInfoClass == null)
        {
            throw new DataNotFoundException("該id查無此資料");
        }
        try
        {
            _medicineContext.medicineInfoClass.Remove(medicineInfoClass);
            // 此時 EntityState = Deleted = delete
            _medicineContext.SaveChanges();
        }
        catch (Exception e)
        {
            _logger.LogError(e.ToString());
            throw new DataBaseException("資料庫發生問題");
        }
    }

    public void Update(MedicineInfoClass medicineInfoClass)
    {
        var resault = (from a in _medicineContext.medicineInfoClass
                       where a.MedicineInfoClassId == medicineInfoClass.MedicineInfoClassId
                       select a).SingleOrDefault();
        // 此時 EntityState = Modified = update
        if (resault == null)
        {
            throw new DataNotFoundException("該id查無此資料");
        }

        try
        {
            resault.MedicineInfoId = medicineInfoClass.MedicineInfoId;
            resault.MedicineClassId = medicineInfoClass.MedicineClassId;
            _medicineContext.SaveChanges();
        }
        catch (Exception e)
        {
            _logger.LogError(e.ToString());
            throw new DataBaseException("資料庫發生問題");
        }
    }

    public MedicineInfoClass GetOne(Guid id)
    {
        // === 1 ===
        // var medicineInfo = _medicineContext.medicineInfos.Find(id);
        // === 2 ===
        var medicineInfoClass = (from a in _medicineContext.medicineInfoClass
                                 where a.MedicineInfoClassId == id
                            select a).SingleOrDefault();
        // === 3 ===
        //var medicineInfo = _medicineContext.medicineInfos
        //    .FromSqlRaw($"select * from medicineinfos where id = '{id}'").SingleOrDefault();
        if (medicineInfoClass == null)
        {
            throw new DataNotFoundException("查無此id");
        }
        return medicineInfoClass;
    }
    public IEnumerable<MedicineInfoClass> GetAll()
    {
        // 1
        //var medicineinfolist = _medicineContext.medicineInfos;
        // 2
        var medicineInfoClassList = (from a in _medicineContext.medicineInfoClass
                                     select a).ToList();
        // 3
        //var medicineInfoList = _medicineContext.medicineInfos
        //    .FromSqlRaw("select * from medicineinfos")
        //    .ToList(); 

        return medicineInfoClassList;
    }
}
