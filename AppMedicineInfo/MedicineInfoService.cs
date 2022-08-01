﻿using MedicineTag.Models;
using MedicineTag.AppException;

namespace MedicineTag.AppMedicineInfo;

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
                            where a.MedicineInfoId == id
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
                       where a.MedicineInfoId == medicineInfo.MedicineInfoId
                       select a).SingleOrDefault();
        // 此時 EntityState = Modified = update
        if (resault == null)
        {
            throw new DataNotFoundException("該id查無此資料");
        }

        try
        {
            resault.UpdateTime = DateTime.Now;

            resault.MedicineInfoName = medicineInfo.MedicineInfoName;
            _medicineContext.SaveChanges();
        }
        catch (Exception e)
        {
            _logger.LogError(e.ToString());
            throw new DataBaseException("資料庫發生問題");
        }
    }

    public MedicineInfo GetOne(Guid id)
    {
        // === 1 ===
        // var medicineInfo = _medicineContext.medicineInfos.Find(id);
        // === 2 ===
        var medicineInfo = (from a in _medicineContext.medicineInfos
                            where a.MedicineInfoId == id
                            select a).SingleOrDefault();
        // === 3 ===
        //var medicineInfo = _medicineContext.medicineInfos
        //    .FromSqlRaw($"select * from medicineinfos where id = '{id}'").SingleOrDefault();
        if (medicineInfo == null)
        {
            throw new DataNotFoundException("查無此id");
        }
        return medicineInfo;
    }
    public IEnumerable<MedicineInfo> GetAll()
    {
        // 1
        //var medicineinfolist = _medicineContext.medicineInfos;
        // 2
        var medicineInfoList = (from a in _medicineContext.medicineInfos
                                select a).ToList();
        // 3
        //var medicineInfoList = _medicineContext.medicineInfos
        //    .FromSqlRaw("select * from medicineinfos")
        //    .ToList(); 

        return medicineInfoList;
    }

}

