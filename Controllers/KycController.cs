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

            var memberDomain = viewModel.Member.ToMember();

            if (viewModel.PermanentAddress != null)
            {
                var address = viewModel.PermanentAddress.ToAddress();
                address.AddressType = "Permanent";
                memberDomain.Addresses.Add(address);
            }
            if (viewModel.TemporaryAddress != null)
            {
                var temp_address = viewModel.TemporaryAddress.ToAddress();
                temp_address.AddressType = "Temporary";
                memberDomain.Addresses.Add(temp_address);
            }
            if (viewModel.BankDetails != null)
            {
                memberDomain.BankDetails = viewModel.BankDetails.ToBankDetail();
            }

            if (viewModel.OtherDetails != null)
            {
                memberDomain.OtherDetails = viewModel.OtherDetails.ToOtherDetails();
            }

            if (viewModel.Nominee != null)
            {
                memberDomain.Nominee = viewModel.Nominee.ToNominee();
            }
            db.Members.Add(memberDomain);
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
                TemporaryAddress = existingmember.Addresses.FirstOrDefault(a => a.AddressType == "Temporary")?.ToAddressFormViewModel(),
                BankDetails = existingmember.BankDetails.ToBankDetailFormViewModel(),
                OtherDetails = existingmember.OtherDetails.ToOtherDetailsFormViewModel(),
                Nominee = existingmember.Nominee?.ToNomineeFormViewModel()
            };
            return View(updateViewModel);
        }
        [HttpPut("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, KycFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
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


            Console.WriteLine("Edit completed successfully");
            return RedirectToAction("GetKycById", new { id = id });


        }
    }
}
