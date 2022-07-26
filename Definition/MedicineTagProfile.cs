using AutoMapper;
using MedicineTag.DTOs;
using MedicineTag.Models;

namespace MedicineTag.Definition;

public class MedicineTagProfile : Profile
{
    public MedicineTagProfile()
    {
        CreateMap<MedicineInfoDTO, MedicineInfo>();
    }
}

