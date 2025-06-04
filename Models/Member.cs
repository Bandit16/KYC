using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KYC.Models;

public class Member
{
    [Key]
    public int MemberId { get; set; }

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string? MiddleName { get; set; }

    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [Required]
    public int EmployeeId { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }

    [Required]
    [StringLength(10)]
    public string Gender { get; set; } = null!;

    [Required]
    [StringLength(20)]
    public string CitizenshipNumber { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string Nationality { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string CitizenshipIssueDistrict { get; set; } = null!;

    [Required]
    [Phone]
    public string MobileNumber { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    public List<Address> Addresses { get; set; } = [];

    public OtherDetails? OtherDetails { get; set; }
    public BankDetail? BankDetails { get; set; }
    public Nominee? Nominee { get; set; }
}