using System.ComponentModel.DataAnnotations;

namespace KYC.Models;


public class Nominee
{
    public int NomineeId { get; set; }
    public int? MemberId { get; set; }
    [Required]
    public string FullName { get; set; } = null!;
    [Required]
    public string Relationship { get; set; } = null!;
    [Required]
    public string CitizenshipNumber { get; set; } = null!;
}
