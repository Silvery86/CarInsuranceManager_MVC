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
                ClaimStatus = "Waiting for aproved",
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

        public async Task<IActionResult> EditAsync(int? id)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (currentUser == null)
            {
                // Handle if user is not authenticated
                return RedirectToAction("Login", "Account");
            }
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Claim? claim = _unitOfWork.Claim.Get(u => u.Id == id); // Find only work with primary key
            // Vehicle? vehicle1 = _db.Vehicles.FirstOrDefault(u => u.Id == id); // Can work with other field not only primary key
            //Vehicle? vehicle2 = _db.Vehicles.Where(u => u.Id == id).FirstOrDefault(); // Other method
            if (claim == null)
            {
                return NotFound();
            }
            ClaimVM claimVM = new()
            {
                Claim = claim,
                BillList = _unitOfWork.Billing.GetAllByUserId(currentUser.Id).Select(u => new SelectListItem
                {
                    Text = u.VehicleNumber,
                    Value = u.Id.ToString(),
                }),

            };
            return View(claimVM);
        }
        [HttpPost]
        public async Task<IActionResult> EditAsync(ClaimVM claimVM)
        {
            // Clear existing ModelState errors
            ModelState.Clear();

            // Check if VehicleValue is greater than zero
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (currentUser == null)
            {
                // Handle if user is not authenticated
                return RedirectToAction("Login", "Account");
            }

            // Fetch the existing claim from the data store
            var existingClaim = _unitOfWork.Claim.Get(u => u.Id == claimVM.Claim.Id);

            if (existingClaim == null)
            {
                // Handle if the claim does not exist
                return NotFound();
            }

            // Update the properties of the existing claim
            existingClaim.CustomerId = currentUser.Id;
            existingClaim.CustomerName = claimVM.Claim.CustomerName;
            existingClaim.BillingId = claimVM.Claim.BillingId;
            existingClaim.BillNo = claimVM.Claim.BillNo;
            existingClaim.VehiclePolicyType = claimVM.Claim.VehiclePolicyType;
            existingClaim.PolicyStartDate = claimVM.Claim.PolicyStartDate;
            existingClaim.PolicyEndDate = claimVM.Claim.PolicyEndDate;
            existingClaim.PolicyDuration = claimVM.Claim.PolicyDuration;
            existingClaim.VehicleName = claimVM.Claim.VehicleName;
            existingClaim.VehicleModel = claimVM.Claim.VehicleModel;
            existingClaim.VehicleNumber = claimVM.Claim.VehicleNumber;
            existingClaim.VehicleVersion = claimVM.Claim.VehicleVersion;
            existingClaim.VehicleRate = claimVM.Claim.VehicleRate;
            existingClaim.VehicleWarranty = claimVM.Claim.VehicleWarranty;
            existingClaim.VehicleValue = claimVM.Claim.VehicleValue;
            existingClaim.InsuranceCost = claimVM.Claim.InsuranceCost;
            existingClaim.PlaceOfAccident = claimVM.Claim.PlaceOfAccident;
            existingClaim.DateOfAccident = claimVM.Claim.DateOfAccident;
            existingClaim.InsuranceAmount = claimVM.Claim.InsuranceAmount;
            existingClaim.ClaimableAmount = claimVM.Claim.ClaimableAmount;
            existingClaim.ClaimStatus = "Processing";

            if (ModelState.IsValid)
            {
                _unitOfWork.Claim.Update(existingClaim);
                TempData["success"] = "Claim edited successfully";
                _unitOfWork.Save();
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteAsync(int? id)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (currentUser == null)
            {
                // Handle if user is not authenticated
                return RedirectToAction("Login", "Account");
            }
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Claim? claim = _unitOfWork.Claim.Get(u => u.Id == id); // Find only work with primary key
            // Vehicle? vehicle1 = _db.Vehicles.FirstOrDefault(u => u.Id == id); // Can work with other field not only primary key
            //Vehicle? vehicle2 = _db.Vehicles.Where(u => u.Id == id).FirstOrDefault(); // Other method
            if (claim == null)
            {
                return NotFound();
            }
            return View(claim);
        }
        [HttpPost, ActionName("Delete")]

        public IActionResult DeletePOST(int? id)
        {
            Claim? claim = _unitOfWork.Claim.Get(u => u.Id == id);
            if (claim == null)
            {
                return NotFound();
            }
            _unitOfWork.Claim.Remove(claim);
            _unitOfWork.Save();
            TempData["success"] = "Claim remove successfully";
            return RedirectToAction("Index");

        }



    }
}
