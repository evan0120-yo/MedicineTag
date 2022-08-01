using AutoMapper;
using MedicineTag.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicineTag.AppMedicineClass;

[ApiController]
[Route("[controller]")]
public class MedicineClassController : ControllerBase
{
    private readonly MedicineContext _medicineContext;

    private readonly IMedicineClassService _medicineClassService;

    private readonly IMapper _IMapper;

    public MedicineClassController(MedicineContext medicineContext,
            IMedicineClassService medicineClassService, IMapper IMapper)
    {
        _medicineContext = medicineContext;
        _medicineClassService = medicineClassService;
        _IMapper = IMapper;
    }

    [HttpPost("/medicineClass")]
    public ActionResult<MedicineClass> Add([FromBody] MedicineClassDTO medicineClassDTO)
    {
        MedicineClass medicineClass = _IMapper.Map<MedicineClass>(medicineClassDTO);
        _medicineClassService.Add(medicineClass);
        return CreatedAtAction(nameof(GetById), new { id = medicineClass.MedicineClassId }, medicineClass);
    }

    [HttpDelete("/medicineClass/{id}")]
    public void Delete(Guid id)
    {
        _medicineClassService.Delete(id);
    }

    [HttpPut("/medicineClass")]
    public ActionResult<MedicineClass> Update([FromBody] MedicineClassDTO medicineClassDTO)
    {
        MedicineClass medicineClass = _IMapper.Map<MedicineClass>(medicineClassDTO);
        _medicineClassService.Update(medicineClass);
        return CreatedAtAction(nameof(GetById), new { id = medicineClass.MedicineClassId }, medicineClass);
    }

    [HttpGet("/medicineClass")]
    public IEnumerable<MedicineClass> GetAll()
    {
        IEnumerable<MedicineClass> medicineClassList = _medicineClassService.GetAll();
        return medicineClassList;
    }

    [HttpGet("/medicineClass/{id}")]
    public ActionResult<MedicineClass> GetById(Guid id)
    {
        MedicineClass medicineClass = _medicineClassService.GetOne(id);
        return medicineClass;
    }

}
