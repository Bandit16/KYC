using System.ComponentModel.DataAnnotations;

namespace KYC.Models;


public class Nominee
{
    public int NomineeId { get; set; }
    public int? MemberId { get; set; }
    public string? FullName { get; set; }
    public string? Relationship { get; set; }
    public string? CitizenshipNumber { get; set; }
}
