using AutoMapper;
using MedicineTag.AppMedicineInfo;

namespace MedicineTag.Definition;

public class MedicineTagProfile : Profile
{
    public MedicineTagProfile()
    {
        CreateMap<MedicineInfoDTO, MedicineInfo>();
    }
}

