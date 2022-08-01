using AutoMapper;
using MedicineTag.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicineTag.AppMedicineInfoClass;

[ApiController]
[Route("[controller]")]
public class MedicineInfoClassController : ControllerBase
{
    private readonly MedicineContext _medicineContext;

    private readonly IMedicineInfoClassService _medicineInfoClassService;

    private readonly IMapper _IMapper;

    public MedicineInfoClassController(MedicineContext medicineContext,
            IMedicineInfoClassService medicineInfoClassService, IMapper IMapper)
    {
        _medicineContext = medicineContext;
        _medicineInfoClassService = medicineInfoClassService;
        _IMapper = IMapper;
    }

    [HttpPost("/medicineInfoClass")]
    public ActionResult<MedicineInfoClass> Add([FromBody] MedicineInfoClassDTO medicineInfoClassDTO)
    {
        MedicineInfoClass medicineInfoClass = _IMapper.Map<MedicineInfoClass>(medicineInfoClassDTO);
        _medicineInfoClassService.Add(medicineInfoClass);
        return CreatedAtAction(nameof(GetById), new { id = medicineInfoClass.MedicineInfoClassId }, medicineInfoClass);
    }

    [HttpDelete("/medicineInfoClass/{id}")]
    public void Delete(Guid id)
    {
        _medicineInfoClassService.Delete(id);
    }

    [HttpPut("/medicineInfoClass")]
    public ActionResult<MedicineInfoClass> Update([FromBody] MedicineInfoClassDTO medicineInfoClassDTO)
    {
        MedicineInfoClass medicineInfoClass = _IMapper.Map<MedicineInfoClass>(medicineInfoClassDTO);
        _medicineInfoClassService.Update(medicineInfoClass);
        return CreatedAtAction(nameof(GetById), new { id = medicineInfoClass.MedicineInfoClassId }, medicineInfoClass);
    }


    [HttpGet("/medicineInfoClass")]
    public IEnumerable<MedicineInfoClass> GetAll()
    {
        IEnumerable<MedicineInfoClass> medicineInfoClassList =  _medicineInfoClassService.GetAll();
        return medicineInfoClassList;
    }

    [HttpGet("/medicineInfoClass/{id}")]
    public ActionResult<MedicineInfoClass> GetById(Guid id)
    {
        MedicineInfoClass medicineInfoClass = _medicineInfoClassService.GetOne(id);
        return medicineInfoClass;
    }

}
