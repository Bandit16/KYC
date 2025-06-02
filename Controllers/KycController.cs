using KYC.Data;
using KYC.Mapping;
using KYC.Models;
using KYC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace KYC.Controllers
{
    public class KycController(KycContext db) : Controller
    {
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
    }
}
