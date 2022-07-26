using Microsoft.AspNetCore.Mvc;
using MedicineTag.Models;
using MedicineTag.Service.Impl;
using MedicineTag.DTOs;
using AutoMapper;

namespace MedicineTag.Controllers;

[ApiController]
[Route("[controller]")]
public class MedicineInfoController : ControllerBase
{

    private readonly MedicineContext _medicineContext;

    private readonly IMedicineInfoService _medicineInfoService;

    private readonly IMapper _IMapper;

    public MedicineInfoController(MedicineContext medicineContext, 
        IMedicineInfoService medicineInfoService, IMapper IMapper)
    {
        _medicineContext = medicineContext;
        _medicineInfoService = medicineInfoService;
        _IMapper = IMapper;
    }


    [HttpPost()]
    public ActionResult<MedicineInfo> Add([FromBody] MedicineInfoDTO medicineInfoDTO)
    {
        MedicineInfo medicineInfo = _IMapper.Map<MedicineInfo>(medicineInfoDTO);
        _medicineInfoService.Add(medicineInfo);
        return CreatedAtAction(nameof(GetById), new { id = medicineInfo.Id }, medicineInfo);
    }

    [HttpDelete("/{id}")]
    public void Delete(Guid id)
    {
        _medicineInfoService.Delete(id);
    }

    [HttpPut()]
    public ActionResult<MedicineInfo> Update([FromBody] MedicineInfoDTO medicineInfoDTO)
    {
        MedicineInfo medicineInfo = _IMapper.Map<MedicineInfo>(medicineInfoDTO);
        _medicineInfoService.Update(medicineInfo);
        return CreatedAtAction(nameof(GetById), new { id = medicineInfo.Id }, medicineInfo);
    }

    [HttpGet()]
    public ActionResult<IEnumerable<MedicineInfo>> GetAll()
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

    [HttpGet("/{id}")]
    public ActionResult<MedicineInfo> GetById(Guid id)
    {
        // === 1 ===
        // var medicineInfo = _medicineContext.medicineInfos.Find(id);
        // === 2 ===
        var medicineInfo = (from a in _medicineContext.medicineInfos
                            where a.Id == id
                            select a).SingleOrDefault();
        // === 3 ===
        //var medicineInfo = _medicineContext.medicineInfos
        //    .FromSqlRaw($"select * from medicineinfos where id = '{id}'").SingleOrDefault();
        if (medicineInfo == null)
        {
            return NotFound();
            // return BadRequest();
        }
        return medicineInfo;
    }

}