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
        _medicineContext.SaveChanges();
        return "刪除成功";
    }

    [HttpPut("/medicineInfo")]
    public ActionResult<String> UpdatePut([FromBody]MedicineInfo medicineInfo)
    {
        var resault = _medicineContext.medicineInfos.Find(medicineInfo.id);
        if(resault == null)
        {
            return NotFound();
        }
        _medicineContext.Entry(medicineInfo).State = EntityState.Detached;
        _medicineContext.medicineInfos.Update(medicineInfo);
        _medicineContext.SaveChanges();
        return "更新成功";
    }

    [HttpGet("/medicineInfo")]
    public ActionResult<IEnumerable<MedicineInfo>> Get()
    {
        return _medicineContext.medicineInfos;
    }

    [HttpGet("/medicineInfo/{id}")]
    public ActionResult<MedicineInfo> GetById(Guid id)
    {
        var medicineInfo = _medicineContext.medicineInfos.Find(id);
        if(medicineInfo == null)
        {
            return NotFound();
            // return BadRequest();
        }
        return medicineInfo;
    }

}