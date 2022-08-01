using MedicineTag.Models;

namespace MedicineTag.AppMedicineInfo;

public class MedicineInfoUseCase
{
    private readonly IMedicineInfoService _medicineInfoService;
    private readonly ILogger<IMedicineInfoService> _logger;

    public MedicineInfoUseCase(IMedicineInfoService medicineInfoService, ILogger<IMedicineInfoService> logger)
    {
        _medicineInfoService = medicineInfoService;
        _logger = logger;
    }

    public void AddMedicineInfo(MedicineInfoDTO medicineInfoDTO)
    {
        if (medicineInfoDTO.MedicineInfoName != null)
        {
            // 新增medicineInfo
            MedicineInfo medicineInfo = new();
            medicineInfo.MedicineInfoName = medicineInfoDTO.MedicineInfoName;
            _medicineInfoService.Add(medicineInfo);
            // 再新增medicineClass
            string[]? medicineClassNameList = medicineInfoDTO.MedicineClassName;

            // 最後再新增關聯 medicineInfoClass

        }


     
    }
}
