using AutoMapper;
using MedicineTag.AppMedicineClass;
using MedicineTag.AppMedicineInfo;
using MedicineTag.AppMedicineInfoClass;

namespace MedicineTag.Definition;

public class MedicineTagProfile : Profile
{
    public MedicineTagProfile()
    {
        CreateMap<MedicineInfoDTO, MedicineInfo>();

        //CreateMap<MedicineInfoDTO, >

        CreateMap<MedicineClassDTO, MedicineClass>();

        CreateMap<MedicineInfoClassDTO, MedicineInfoClass>();
    }
}

