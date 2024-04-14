using CarInsurance.DataAccess.Repository.IRepository;
using CarInsurance.Models;
using CarInsurance.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarInsuranceManagerWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class BillingController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        public BillingController(UserManager<IdentityUser> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;

        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account"); // Redirect if user is not authenticated
            }

            // Fetch vehicles for the current user
            List<Billing> bills = (List<Billing>)_unitOfWork.Billing.GetAll();
            // Iterate over each vehicle to fetch associated UserName

            return View(bills);
        }


        public async Task<IActionResult> SendInvoiceActionAsync()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account"); // Redirect if user is not authenticated
            }

            // Fetch vehicles for the current user
            List<Billing> bills = (List<Billing>)_unitOfWork.Billing.GetAll();
            // Iterate over each vehicle to fetch associated UserName

            TempData["success"] = "Bill sent to customer successfully!";
            return View("Index", bills);
        }

    }
}
