namespace KYC.Dtos;

public record class DistrictDto
{
    public int Id { get; init; }
    public string Name { get; init; } = default!;
}
