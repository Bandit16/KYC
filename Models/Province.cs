using System;

namespace KYC.Models;

public class Province
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public List<District>? Districts { get; set; }
}
