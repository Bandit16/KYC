using System.Threading.Tasks;
using KYC.Data;
using KYC.Mapping;
using KYC.Models;
using KYC.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
namespace KYC.Controllers
{
    public class KycController(KycContext db) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var members = await db.Members.ToListAsync();
            Console.WriteLine("index invoked");

            return View(members);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var ViewModel = new KycFormViewModel(

            );

            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(KycFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var newMember = viewModel.Member.ToMember();

            if (viewModel.PermanentAddress != null)
            {
                var address = viewModel.PermanentAddress.ToAddress();
                address.AddressType = "Permanent";
                newMember.Addresses.Add(address);
            }
            if (viewModel.TemporaryAddress != null)
            {
                var temp_address = viewModel.TemporaryAddress.ToAddress();
                temp_address.AddressType = "Temporary";
                newMember.Addresses.Add(temp_address);
            }
            if (viewModel.BankDetails != null)
            {
                newMember.BankDetails = viewModel.BankDetails.ToBankDetail();
            }

            if (viewModel.OtherDetails != null)
            {
                newMember.OtherDetails = viewModel.OtherDetails.ToOtherDetails();
            }

            if (viewModel.Nominee != null)
            {
                newMember.Nominee = viewModel.Nominee.ToNominee();
            }
            db.Members.Add(newMember);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");

        }
        [HttpGet("profile/{id}")]
        public async Task<IActionResult> GetKycById(int id)
        {
            var member = await db.Members
            .Include(m => m.Addresses)
            .Include(m => m.BankDetails)
            .Include(m => m.OtherDetails)
            .Include(m => m.Nominee)
            .FirstOrDefaultAsync(m => m.MemberId == id);

            if (member == null)
            {
                return NotFound();
            }

            var viewModel = new KycFormViewModel
            {
                Member = member.ToMemberFormViewModel(),
                PermanentAddress = member.Addresses.FirstOrDefault(a => a.AddressType == "Permanent")?.ToAddressFormViewModel() ?? new AddressFormViewModel(),
                TemporaryAddress = member.Addresses.FirstOrDefault(a => a.AddressType == "Temporary")?.ToAddressFormViewModel(),
                BankDetails = member.BankDetails.ToBankDetailFormViewModel(),
                OtherDetails = member.OtherDetails.ToOtherDetailsFormViewModel(),
                Nominee = member.Nominee?.ToNomineeFormViewModel()
            };

            return View(viewModel);
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var existingmember = await db.Members
            .Include(m => m.Addresses)
            .Include(m => m.BankDetails)
            .Include(m => m.OtherDetails)
            .Include(m => m.Nominee)
            .FirstOrDefaultAsync(m => m.MemberId == id);
            if (existingmember == null)
            {
                return NotFound();
            }
            var updateViewModel = new KycFormViewModel
            {
                Member = existingmember.ToMemberFormViewModel(),
                PermanentAddress = existingmember.Addresses.FirstOrDefault(a => a.AddressType == "Permanent")?.ToAddressFormViewModel() ?? new AddressFormViewModel(),
                TemporaryAddress = existingmember.Addresses.FirstOrDefault(a => a.AddressType == "Temporary")?.ToAddressFormViewModel() ?? new AddressFormViewModel(),
                BankDetails = existingmember.BankDetails?.ToBankDetailFormViewModel() ?? new BankDetailFormViewModel(),
                OtherDetails = existingmember.OtherDetails?.ToOtherDetailsFormViewModel() ?? new OtherDetailsFormViewModel(),
                Nominee = existingmember.Nominee?.ToNomineeFormViewModel() ?? new NomineeFormViewModel()
            };
            return View(updateViewModel);
        }


        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, KycFormViewModel updatedViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedViewModel);
            }
            var existingMember = await db.Members
                .Include(m => m.Addresses)
                .Include(m => m.BankDetails)
                .Include(m => m.OtherDetails)
                .Include(m => m.Nominee)
                .FirstOrDefaultAsync(m => m.MemberId == id);

            if (existingMember == null)
            {
                return NotFound();
            }
            try
            {
                //hadto manually set values because couldnt use setvalues/update as it tried to update my fk.....couldnt use my mapping extension methods
                existingMember.FirstName = updatedViewModel.Member.FirstName;
                existingMember.LastName = updatedViewModel.Member.LastName;
                if (updatedViewModel.Member.MiddleName != null)
                {
                    existingMember.MiddleName = updatedViewModel.Member.MiddleName;
                }
                existingMember.Gender = updatedViewModel.Member.Gender;
                existingMember.DateOfBirth = updatedViewModel.Member.DateOfBirth;
                existingMember.CitizenshipNumber = updatedViewModel.Member.CitizenshipNumber;
                existingMember.CitizenshipIssueDistrict = updatedViewModel.Member.CitizenshipIssueDistrict;
                existingMember.MobileNumber = updatedViewModel.Member.MobileNumber;
                existingMember.Email = updatedViewModel.Member.Email;
                existingMember.Gender = updatedViewModel.Member.Gender;
                existingMember.Nationality = updatedViewModel.Member.Nationality;
                existingMember.EmployeeId = updatedViewModel.Member.EmployeeId;

                if (updatedViewModel.BankDetails != null)
                {
                    if (existingMember.BankDetails == null)
                    {
                        existingMember.BankDetails = updatedViewModel.BankDetails.ToBankDetail();
                    }
                    else
                    {
                        var bankDetail = updatedViewModel.BankDetails;
                        existingMember.BankDetails.BankName = bankDetail.BankName;
                        existingMember.BankDetails.AccountNumber = bankDetail.AccountNumber;
                        existingMember.BankDetails.Branch = bankDetail.Branch;
                    }
                }

                if (updatedViewModel.OtherDetails != null)
                {
                    if (existingMember.OtherDetails == null)
                    {
                        existingMember.OtherDetails = updatedViewModel.OtherDetails.ToOtherDetails();
                    }
                    else
                    {
                        var otherDetails = updatedViewModel.OtherDetails;
                        existingMember.OtherDetails.FatherName = otherDetails.FatherName;
                        existingMember.OtherDetails.MotherName = otherDetails.MotherName;
                        if (otherDetails.SpouseName != null)
                        {

                            existingMember.OtherDetails.SpouseName = otherDetails.SpouseName;
                        }
                    }
                }

                if (updatedViewModel.Nominee != null)
                {
                    if (existingMember.Nominee == null)
                    {
                        existingMember.Nominee = updatedViewModel.Nominee.ToNominee();
                    }
                    else
                    {
                        var nominee = updatedViewModel.Nominee;
                        existingMember.Nominee.FullName = nominee.FullName;
                        existingMember.Nominee.Relationship = nominee.Relationship;
                        existingMember.Nominee.CitizenshipNumber = nominee.CitizenshipNumber;

                    }
                }
                else
                {
                    existingMember.Nominee = null;
                }

                var existingPermanentAddress = existingMember.Addresses.FirstOrDefault(a => a.AddressType == "Permanent");
                if (updatedViewModel.PermanentAddress != null)
                {
                    var newPermanentAddress = updatedViewModel.PermanentAddress;
                    if (existingPermanentAddress == null)
                    {
                        var address = newPermanentAddress.ToAddress();
                        address.AddressType = "Permanent";
                        existingMember.Addresses.Add(address);
                    }
                    else
                    {
                        existingPermanentAddress.Province = newPermanentAddress.SelectedProvince;
                        existingPermanentAddress.District = newPermanentAddress.SelectedDistrict;
                        existingPermanentAddress.Municipality = newPermanentAddress.Municipality;
                        existingPermanentAddress.Ward = newPermanentAddress.Ward;
                        existingPermanentAddress.Tole = newPermanentAddress.Tole;
                    }
                }
                else if (existingPermanentAddress != null)
                {
                    existingMember.Addresses.Remove(existingPermanentAddress);
                }

                var existingTemporaryAddress = existingMember.Addresses.FirstOrDefault(a => a.AddressType == "Temporary");
                if (updatedViewModel.TemporaryAddress != null)
                {
                    var newTemporaryAddress = updatedViewModel.TemporaryAddress;
                    if (existingTemporaryAddress == null)
                    {
                        var address = newTemporaryAddress.ToAddress();
                        address.AddressType = "Temporary";
                        existingMember.Addresses.Add(address);
                    }
                    else
                    {
                        existingTemporaryAddress.Province = newTemporaryAddress.SelectedProvince;
                        existingTemporaryAddress.District = newTemporaryAddress.SelectedDistrict;
                        existingTemporaryAddress.Municipality = newTemporaryAddress.Municipality;
                        existingTemporaryAddress.Ward = newTemporaryAddress.Ward;
                        existingTemporaryAddress.Tole = newTemporaryAddress.Tole;
                    }
                }
                else if (existingTemporaryAddress != null)
                {
                    existingMember.Addresses.Remove(existingTemporaryAddress);
                }

                await db.SaveChangesAsync();
                Console.WriteLine("Edit completed successfully");
                return RedirectToAction("GetKycById", new { id = id });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Edit failed: {ex.Message}");
                ModelState.AddModelError("", "An error occurred while updating the record.");
                return View(updatedViewModel);
            }

        }
        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(int id)
        {
            var existingMember = await db.Members.FindAsync(id);
            if (existingMember == null)
            {
                return NotFound();
            }
            db.Members.Remove(existingMember);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Kyc");
        }
    }
}
