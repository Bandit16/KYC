using System;
using KYC.Models;
using KYC.ViewModels;

namespace KYC.Mapping;

public static class ViewModelMapping
{
    public static Address ToAddress(this AddressFormViewModel a)
    {
        return new Address
        {
            Province = a.SelectedProvince,
            District = a.SelectedDistrict,
            Municipality = a.Municipality,
            Ward = a.Ward,
            Tole = a.Tole

        };

    }
    public static BankDetail ToBankDetail(this BankDetailFormViewModel b)
    {
        return new BankDetail
        {
            BankName = b.BankName,
            AccountNumber = b.AccountNumber,
            Branch = b.Branch,

        };
    }
    public static Nominee ToNominee(this NomineeFormViewModel n)
    {
        return new Nominee
        {
            FullName = n.FullName,
            Relationship = n.Relationship,
            CitizenshipNumber = n.CitizenshipNumber

        };
    }
    public static OtherDetails ToOtherDetails(this OtherDetailsFormViewModel o)
    {
        return new OtherDetails
        {
            FatherName = o.FatherName,
            MotherName = o.MotherName,
            GrandFatherName = o.GrandFatherName,
            SpouseName = o.SpouseName
        };
    }
    public static Member ToMember(this MemberFormViewModel m)
    {
        return new Member
        {
            FirstName = m.FirstName,
            MiddleName = m.MiddleName,
            LastName = m.LastName,
            EmployeeId = m.EmployeeId,
            DateOfBirth = m.DateOfBirth,
            Gender = m.Gender,
            CitizenshipNumber = m.CitizenshipNumber,
            Nationality = m.Nationality,
            CitizenshipIssueDistrict = m.CitizenshipIssueDistrict,
            MobileNumber = m.MobileNumber,
            Email = m.Email

        };
    }
    public static MemberFormViewModel ToMemberFormViewModel(this Member m)
    {
        return new MemberFormViewModel
        {
            FirstName = m.FirstName,
            MiddleName = m.MiddleName,
            LastName = m.LastName,
            EmployeeId = m.EmployeeId,
            DateOfBirth = m.DateOfBirth,
            Gender = m.Gender,
            CitizenshipNumber = m.CitizenshipNumber,
            Nationality = m.Nationality,
            CitizenshipIssueDistrict = m.CitizenshipIssueDistrict,
            MobileNumber = m.MobileNumber,
            Email = m.Email

        };
    }
    public static AddressFormViewModel ToAddressFormViewModel(this Address a)
    {
        return new AddressFormViewModel
        {
            SelectedProvince = a.Province,
            SelectedDistrict = a.District,
            Municipality = a.Municipality,
            Ward = a.Ward,
            Tole = a.Tole

        };

    }
    public static BankDetailFormViewModel ToBankDetailFormViewModel(this BankDetail b)
    {
        return new BankDetailFormViewModel
        {
            BankName = b.BankName,
            AccountNumber = b.AccountNumber,
            Branch = b.Branch,

        };
    }
    public static NomineeFormViewModel ToNomineeFormViewModel(this Nominee n)
    {
        return new NomineeFormViewModel
        {
            FullName = n.FullName,
            Relationship = n.Relationship,
            CitizenshipNumber = n.CitizenshipNumber

        };
    }
    public static OtherDetailsFormViewModel ToOtherDetailsFormViewModel(this OtherDetails o)
    {
        return new OtherDetailsFormViewModel
        {
            FatherName = o.FatherName,
            MotherName = o.MotherName,
            GrandFatherName = o.GrandFatherName,
            SpouseName = o.SpouseName
        };
    }

}
