using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KYC.Models;

public partial class KycFormModel
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }

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
        public Gender Gender { get; set; }

        [Required]
        public string CitizenshipNumber { get; set; } = null!;

        [Required]
        public string Nationality { get; set; } = null!;

        [Required]
        public string CitizenshipIssueDistrict { get; set; } = null!;

        [Required]
        public int MobileNumber { get; set; }

        [Required]
        public string Email { get; set; } = null!;

        public int PermanentAddressId { get; set; }
        public Address PermanentAddress { get; set; } = null!;

        public int TemporaryAddressId { get; set; }
        public Address TemporaryAddress { get; set; } = null!;

        public int OtherDetailsId { get; set; }
        public OtherDetails OtherDetails { get; set; } = null!;

        public int BankDetailsId { get; set; }
        public BankDetail BankDetails { get; set; } = null!;

        public int? NomineeId { get; set; }
        public Nominee? Nominee { get; set; }
    }
}