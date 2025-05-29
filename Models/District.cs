using System;

namespace KYC.Models;

public class District
{
    public int Id { get; set; }
    public required string Name { get; set; }

    // Foreign key for Province
    public int ProvinceId { get; set; }
    public Province Province { get; set; } = null!;
}
