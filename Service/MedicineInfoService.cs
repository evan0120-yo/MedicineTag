using MedicineTag.Models;
using MedicineTag.AppException;
using MedicineTag.Service.Impl;


namespace MedicineTag.Service;

public class MedicineInfoService : IMedicineInfoService
{
    private readonly MedicineContext _medicineContext;
    private readonly ILogger<IMedicineInfoService> _logger;

    public MedicineInfoService(MedicineContext medicineContext, ILogger<IMedicineInfoService> logger)
    {
        _medicineContext = medicineContext;
        _logger = logger;
    }

    public void Add(MedicineInfo medicineInfo)
    {
        medicineInfo.CreateTime = DateTime.Now;
        medicineInfo.UpdateTime = DateTime.Now;
        try
        {
            _medicineContext.Add(medicineInfo);
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
        var medicineInfo = (from a in _medicineContext.medicineInfos
                            where a.Id == id
                            select a).SingleOrDefault();

        if (medicineInfo == null)
        {
            throw new DataNotFoundException("該id查無此資料");
        }
        try
        {
            _medicineContext.medicineInfos.Remove(medicineInfo);
            // 此時 EntityState = Deleted = delete
            _medicineContext.SaveChanges();
        }
        catch (Exception e)
        {
            _logger.LogError(e.ToString());
            throw new DataBaseException("資料庫發生問題");
        }
    }

    public void Update(MedicineInfo medicineInfo)
    {
        // 1
        //var resault = _medicineContext.medicineInfos.Find(medicineInfo.id);
        // 2
        var resault = (from a in _medicineContext.medicineInfos
                       where a.Id == medicineInfo.Id
                       select a).SingleOrDefault();
        // 此時 EntityState = Modified = update
        if (resault == null)
        {
            throw new DataNotFoundException("該id查無此資料");
        }

        try
        {
            resault.UpdateTime = DateTime.Now;

            resault.Name = medicineInfo.Name;
            _medicineContext.SaveChanges();
        }
        catch (Exception e)
        {
            _logger.LogError(e.ToString());
            throw new DataBaseException("資料庫發生問題");
        }
    }

}

