using KYC.Data;
using KYC.Mapping;
using KYC.Models;
using KYC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using static KYC.Models.KycFormModel;

namespace KYC.Controllers
{
    public class KycController() : Controller
    {
        public IActionResult Index()
        {
            var ViewModel = new KycFormViewModel();

            return View(ViewModel);
        }


    }
}
