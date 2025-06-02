using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KYC.Models;


public class Member
{
    [Key]
    public int MemberId { get; set; }

    [Required]
    public string FirstName { get; set; } = null!;
    public string? MiddleName { get; set; }

    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    public int EmployeeId { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }

    [Required]
    public string Gender { get; set; } = null!;

    [Required]
    public string CitizenshipNumber { get; set; } = null!;

    [Required]
    public string Nationality { get; set; } = null!;

    [Required]
    public string CitizenshipIssueDistrict { get; set; } = null!;

    public int MobileNumber { get; set; }

    [Required]
    public string Email { get; set; } = null!;

    public List<Address> Addresses { get; set; } = [];


    public OtherDetails OtherDetails { get; set; } = null!;

    public BankDetail BankDetails { get; set; } = null!;

    public Nominee? Nominee { get; set; }
}