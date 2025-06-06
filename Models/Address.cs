using System.ComponentModel.DataAnnotations;

namespace KYC.Models;

public class Address
{
    public int AddressId { get; set; }
    public int? MemberId { get; set; }
    public Member Member { get; set; } = null!;

    [Required]
    public string Province { get; set; } = null!;
    [Required]
    public string District { get; set; } = null!;
    [Required]
    public string Municipality { get; set; } = null!;
    [Required]
    public int Ward { get; set; }
    [Required]
    public string Tole { get; set; } = null!;
    [Required]
    public string AddressType { get; set; } = null!;


}
