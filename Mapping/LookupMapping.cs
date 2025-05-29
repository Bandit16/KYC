using System;
using KYC.Dtos;
using KYC.Models;

namespace KYC.Mapping;

public static class LookupMapping
{
    public static ProvinceDto ProvinceToDto(this Province province)
    {
        return new ProvinceDto
        {
            Id = province.Id,
            Name = province.Name,
        };
    }

    public static DistrictDto DistrictToDto(this District district)
    {
        return new DistrictDto
        {
            Id = district.Id,
            Name = district.Name
        };
    }
}

