using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
// Remove: using static KYC.Models.KycFormModel; // If KYC.Models.KycFormModel is your domain model container
// Remove: using KYC.Models; // If this brings in domain models directly for properties

namespace KYC.ViewModels
{
    // ViewModel for Address fields in the form
    public class AddressFormViewModel
    {
        [Required]
        public string SelectedProvince { get; set; } = string.Empty;
        [Required]
        public string SelectedDistrict { get; set; } = string.Empty;
        [Required]
        public string Municipality { get; set; } = string.Empty;
        [Required]
        public int Ward { get; set; }
        [Required]
        public string Tole { get; set; } = string.Empty;

    }

    public class BankDetailFormViewModel
    {
        [Required]
        [DisplayName("Bank Name")]

        public string BankName { get; set; } = string.Empty;
        [Required]
        [DisplayName("Account Number")]
        public string AccountNumber { get; set; } = string.Empty;
        [Required]
        public string Branch { get; set; } = string.Empty;
    }


    public class OtherDetailsFormViewModel
    {
        [Required]
        public string FatherName { get; set; } = string.Empty;
        [Required]
        public string MotherName { get; set; } = string.Empty;
        [Required]
        public string GrandFatherName { get; set; } = string.Empty;
        public string? SpouseName { get; set; }


    }
    public class NomineeFormViewModel
    {
        [Required]
        public string FullName { get; set; } = string.Empty;
        [Required]
        public string Relationship { get; set; } = string.Empty;
        [Required]
        public string CitizenshipNumber { get; set; } = string.Empty;
    }
    public class MemberFormViewModel
    {
        [Required(ErrorMessage = "First name is required.")]
        [DisplayName("First Name")]
        public string FirstName { get; set; } = string.Empty;
        [DisplayName("Middle Name")]
        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [DisplayName("Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [DisplayName("Employee Id")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        [DataType(DataType.Date)]
        [DisplayName("Date of Birth")]

        public DateTime DateOfBirth { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; } = string.Empty;

        [Required(ErrorMessage = "Citizenship number is required.")]
        [DisplayName("Citizenship Number ")]
        public string CitizenshipNumber { get; set; } = string.Empty;

        [Required]
        public string Nationality { get; set; } = "Nepali";

        [Required]
        public string CitizenshipIssueDistrict { get; set; } = string.Empty;
        [Required]
        [Phone]
        public string MobileNumber { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
    public class KycFormViewModel
    {
        [Required]
        public MemberFormViewModel Member { get; set; }
        [Required]
        public AddressFormViewModel PermanentAddress { get; set; }

        public AddressFormViewModel? TemporaryAddress { get; set; }

        [Required]
        public BankDetailFormViewModel BankDetails { get; set; }

        [Required]
        public OtherDetailsFormViewModel OtherDetails { get; set; }

        public NomineeFormViewModel? Nominee { get; set; }


        public KycFormViewModel()
        {
            Member = new MemberFormViewModel();
            PermanentAddress = new AddressFormViewModel();
            BankDetails = new BankDetailFormViewModel();
            OtherDetails = new OtherDetailsFormViewModel();
            TemporaryAddress = new AddressFormViewModel();
            Nominee = new NomineeFormViewModel();

        }


    }
}
