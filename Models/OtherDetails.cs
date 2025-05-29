using System;
using System.ComponentModel.DataAnnotations;

namespace KYC.Models;

public class OtherDetails
{
    public int Id { get; set; }
    public int MemberId { get; set; }
    [Required]
    public string FatherName { get; set; } = null!;
    [Required]
    public string MotherName { get; set; } = null!;
    [Required]
    public string GrandFatherName { get; set; } = null!;
    public string? SpouseName { get; set; }
}
