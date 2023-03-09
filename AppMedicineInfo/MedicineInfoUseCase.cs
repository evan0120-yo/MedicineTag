using MedicineTag.AppMedicineClass;
using MedicineTag.AppMedicineInfoClass;

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
            //// 新增medicineInfo
            //MedicineInfo medicineInfo = new();
            //medicineInfo.MedicineInfoName = medicineInfoDTO.MedicineInfoName;

            //_medicineInfoService.Add(medicineInfo);
            //// 再新增medicineClass
            //string[]? medicineClassNameList = medicineInfoDTO.MedicineClassName;

            //// 最後再新增關聯 medicineInfoClass


            List<MedicineClass> medicineClassList = new();

            if (medicineInfoDTO.MedicineClassNameList != null)
            {
                foreach (String medicineClassName in medicineInfoDTO.MedicineClassNameList)
                {
                    MedicineClass medicineClass = new();
                    medicineClass.MedicineClassName = medicineClassName;
                    medicineClassList.Add(medicineClass);
                }
            }

            MedicineInfo medicineInfo = new MedicineInfo
            {
                MedicineInfoName = medicineInfoDTO.MedicineInfoName,
                MedicineInfoClassList = list,
            };

            _medicineInfoService.Add(medicineInfo);
        }


     
    }
}
