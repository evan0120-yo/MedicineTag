using Microsoft.AspNetCore.Mvc;
using MedicineTag.Models;
using MedicineTag.Definition;
using Microsoft.EntityFrameworkCore;

namespace MedicineTag.Controllers;

[ApiController]
[Route("[controller]")]
public class MedicineInfoController : ControllerBase
{


    private readonly MedicineContext _medicineContext;

    public MedicineInfoController(MedicineContext medicineContext)
    {
        _medicineContext = medicineContext;
    }

        
    [HttpPost()]
    public ActionResult<MedicineInfo> Add([FromBody]MedicineInfo medicineInfo)
    {
        _medicineContext.Add(medicineInfo);
        // 此時 EntityState = Add = add
        _medicineContext.SaveChanges();
        return CreatedAtAction(nameof(Get), new{ id = medicineInfo.id}, medicineInfo);
    }

    [HttpDelete("/medicineInfo/{id}")]
    public ActionResult<String> Delete(Guid id)
    {
        var medicineInfo = _medicineContext.medicineInfos.Find(id);
        if(medicineInfo == null)
        {
            return NotFound();
        }
        _medicineContext.medicineInfos.Remove(medicineInfo);
        // 此時 EntityState = Deleted = delete
        _medicineContext.SaveChanges();
        return "刪除成功";
    }

    [HttpPut("/medicineInfo")]
    public ActionResult<String> UpdatePut([FromBody]MedicineInfo medicineInfo)
    {
        var resault = _medicineContext.medicineInfos.Find(medicineInfo.id);
        // 此時 EntityState = Modified = update
        if(resault == null)
        {
            return NotFound();
        }
        resault.name = medicineInfo.name;
        _medicineContext.SaveChanges();
        return "更新成功";
    }

    [HttpGet("/medicineInfo")]
    public ActionResult<IEnumerable<MedicineInfo>> Get()
    {
        var medicineInfoList = _medicineContext.medicineInfos;
        return medicineInfoList;
    }

    [HttpGet("/medicineInfo/{id}")]
    public ActionResult<MedicineInfo> GetById(Guid id)
    {
        // var medicineInfo = _medicineContext.medicineInfos.Find(id);
        var medicineInfo = (from a in _medicineContext.medicineInfos 
                            where a.id == id 
                            select a).SingleOrDefault();
        if(medicineInfo == null)
        {
            return NotFound();
            // return BadRequest();
        }
        return medicineInfo;
    }

}