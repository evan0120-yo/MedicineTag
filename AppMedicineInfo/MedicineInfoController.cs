using Microsoft.AspNetCore.Mvc;
using MedicineTag.Models;
using AutoMapper;

namespace MedicineTag.AppMedicineInfo;

[ApiController]
[Route("[controller]")]
public class MedicineInfoController : ControllerBase
{

    private readonly MedicineContext _medicineContext;

    private readonly IMedicineInfoService _medicineInfoService;

    private readonly IMapper _IMapper;

    private readonly ILogger<IMedicineInfoService> _logger;

    public MedicineInfoController(MedicineContext medicineContext,
        IMedicineInfoService medicineInfoService, IMapper IMapper, ILogger<IMedicineInfoService> logger)
    {
        _medicineContext = medicineContext;
        _medicineInfoService = medicineInfoService;
        _IMapper = IMapper;
        _logger = logger;
    }


    [HttpPost("/medicineInfo")]
    public ActionResult<MedicineInfo> Add([FromBody] MedicineInfoDTO medicineInfoDTO)
    {
        MedicineInfo medicineInfo = _IMapper.Map<MedicineInfo>(medicineInfoDTO);
        _medicineInfoService.Add(medicineInfo);
        return CreatedAtAction(nameof(GetById), new { id = medicineInfo.MedicineInfoId }, medicineInfo);
    }

    [HttpPost("/medicineInfo/medInfo")]
    public ActionResult<String> AddMedicineInfo([FromBody] MedicineInfoDTO medicineInfoDTO)
    {
        if (medicineInfoDTO.MedicineInfoName == null)
        {
            return BadRequest("藥品姓名不可為空");
        }
        return "111";
    }

    [HttpDelete("/medicineInfo/{id}")]
    public void Delete(Guid id)
    {
        _medicineInfoService.Delete(id);
    }

    [HttpPut("/medicineInfo")]
    public ActionResult<MedicineInfo> Update([FromBody] MedicineInfoDTO medicineInfoDTO)
    {
        MedicineInfo medicineInfo = _IMapper.Map<MedicineInfo>(medicineInfoDTO);
        _medicineInfoService.Update(medicineInfo);
        return CreatedAtAction(nameof(GetById), new { id = medicineInfo.MedicineInfoId }, medicineInfo);
    }

    [HttpGet("/medicineInfo")]
    public IEnumerable<MedicineInfo> GetAll()
    {
        IEnumerable<MedicineInfo> medicineInfoList = _medicineInfoService.GetAll();
        return medicineInfoList;
    }

    [HttpGet("/medicineInfo/{id}")]
    public ActionResult<MedicineInfo> GetById(Guid id)
    {
        MedicineInfo medicineInfo = _medicineInfoService.GetOne(id);
        return medicineInfo;
    }

}