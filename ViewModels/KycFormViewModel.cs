using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
// Remove: using static KYC.Models.KycFormModel; // If KYC.Models.KycFormModel is your domain model container
// Remove: using KYC.Models; // If this brings in domain models directly for properties

namespace KYC.ViewModels
{
    // ViewModel for Address fields in the form
    public class AddressFormViewModel
    {
        // Use string for SelectedProvince/District if they are names,
        // or int if they are IDs and you have corresponding SelectLists.
        [Required]
        public string SelectedProvince { get; set; } = string.Empty;
        [Required]
        public string SelectedDistrict { get; set; } = string.Empty;
        [Required]
        public string Municipality { get; set; } = string.Empty;
        [Required]
        public int Ward { get; set; } // Assuming Ward is a string, adjust if int
        [Required]
        public string Tole { get; set; } = string.Empty;

        // For dropdowns (populated in controller)
        public IEnumerable<SelectListItem>? Provinces { get; set; }
        public IEnumerable<SelectListItem>? Districts { get; set; }
    }

    // ViewModel for BankDetail fields in the form
    public class BankDetailFormViewModel
    {
        [Required]
        public string BankName { get; set; } = string.Empty;
        [Required]
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

    public class KycFormViewModel
    {
        public int MemberId { get; set; } // Useful for edit scenarios

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; } = string.Empty;

        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; } = DateTime.Today; // Default to today or a sensible default

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; } = string.Empty; // Or use an enum if Gender is an enum

        [Required(ErrorMessage = "Citizenship number is required.")]
        public string CitizenshipNumber { get; set; } = string.Empty;

        [Required]
        public string Nationality { get; set; } = "Nepali"; // Default if applicable

        [Required]
        public string CitizenshipIssueDistrict { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile number must be 10 digits.")]
        public string MobileNumber { get; set; } = string.Empty; // Use string for leading zeros, validate format

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        // Nested ViewModels for related entities
        [Required]
        public AddressFormViewModel PermanentAddress { get; set; }

        public AddressFormViewModel? TemporaryAddress { get; set; } // Optional

        // For a single BankDetail as per your Member model
        [Required]
        public BankDetailFormViewModel BankDetails { get; set; }

        [Required]
        public OtherDetailsFormViewModel OtherDetails { get; set; }

        public NomineeFormViewModel? Nominee { get; set; }


        public KycFormViewModel()
        {
            PermanentAddress = new AddressFormViewModel();
            BankDetails = new BankDetailFormViewModel();
            OtherDetails = new OtherDetailsFormViewModel();
            TemporaryAddress = new AddressFormViewModel();
            Nominee = new NomineeFormViewModel();

        }


    }
}
