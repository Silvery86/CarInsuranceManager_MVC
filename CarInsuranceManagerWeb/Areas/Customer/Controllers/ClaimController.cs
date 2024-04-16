using CarInsurance.DataAccess.Repository.IRepository;
using CarInsurance.Models;
using CarInsurance.Models.ViewModels;
using CarInsurance.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarInsuranceManagerWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = SD.Role_Customer)]
    public class ClaimController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        public ClaimController(UserManager<IdentityUser> userManager, IUnitOfWork unitOfWork)
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
            List<Claim> claims = (List<Claim>)_unitOfWork.Claim.GetAllByUserId(currentUser.Id);
            // Iterate over each vehicle to fetch associated UserName

            return View(claims);
        }

        public async Task<IActionResult> Create()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account"); // Redirect if user is not authenticated
            }

            ClaimVM claimVM = new()
            {

                BillList = _unitOfWork.Billing.GetAllByUserId(currentUser.Id).Select(u => new SelectListItem
                {
                    Text = u.VehicleNumber,
                    Value = u.Id.ToString(),
                }),

            };
            return View(claimVM);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ClaimVM claimVM)
        {
            // Clear existing ModelState errors
            ModelState.Clear();


            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (currentUser == null)
            {
                // Handle if user is not authenticated
                return RedirectToAction("Login", "Account");
            }

            // Assign the current user directly to the IdentityUser navigation property
            claimVM.Claim.CustomerId = currentUser.Id;
            Claim claim = new Claim()
            {
                CustomerId = claimVM.Claim.CustomerId,
                CustomerName = claimVM.Claim.CustomerName,
                BillingId = claimVM.Claim.BillingId,
                BillNo = claimVM.Claim.BillNo,
                VehiclePolicyType = claimVM.Claim.VehiclePolicyType,
                PolicyStartDate = claimVM.Claim.PolicyStartDate,
                PolicyEndDate = claimVM.Claim.PolicyEndDate,
                PolicyDuration = claimVM.Claim.PolicyDuration,
                VehicleName = claimVM.Claim.VehicleName,
                VehicleModel = claimVM.Claim.VehicleModel,
                VehicleNumber = claimVM.Claim.VehicleNumber,
                VehicleVersion = claimVM.Claim.VehicleVersion,
                VehicleRate = claimVM.Claim.VehicleRate,
                VehicleWarranty = claimVM.Claim.VehicleWarranty,
                VehicleValue = claimVM.Claim.VehicleValue,
                InsuranceCost = claimVM.Claim.InsuranceCost,
                PlaceOfAccident = claimVM.Claim.PlaceOfAccident,
                DateOfAccident = claimVM.Claim.DateOfAccident,
                InsuranceAmount = claimVM.Claim.InsuranceAmount,
                ClaimableAmount = claimVM.Claim.ClaimableAmount,
                ClaimStatus = "Processing",
            };

            if (ModelState.IsValid)
            {

                // Add the vehicle to the context and save changes
                _unitOfWork.Claim.Add(claim);
                TempData["success"] = "Claim created successfully";
                await _unitOfWork.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            // Return the view to display validation errors
            return View(claim);
        }
        public IActionResult GetBill(int billId)
        {
            // Your logic to fetch the corresponding VehicleName based on the selected VehicleNumber

            Billing? billing = _unitOfWork.Billing.Get(u => u.Id == billId);
            return Json(billing);
        }


    }
}
