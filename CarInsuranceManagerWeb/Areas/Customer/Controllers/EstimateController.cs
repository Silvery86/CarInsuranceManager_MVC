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
    public class EstimateController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        public EstimateController(UserManager<IdentityUser> userManager, IUnitOfWork unitOfWork)
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

            EstimateVM estimateVM = new()
            {
                VehicleList = _unitOfWork.Vehicle.GetAllByUserId(currentUser.Id).Select(u => new SelectListItem
                {
                    Text = u.Number,
                    Value = u.Id.ToString(),
                }),
                PolicyList = _unitOfWork.Policy.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                }),

            };
            return View(estimateVM);
        }
        [HttpPost]
        public IActionResult Index(EstimateVM model)
        {
            return RedirectToAction("Checkout", model);
        }

        public IActionResult Checkout(EstimateVM model)
        {
            return View(model);
        }

        [HttpPost]
        public IActionResult GetVehicle(int vehicleId)
        {
            // Your logic to fetch the corresponding VehicleName based on the selected VehicleNumber

            Vehicle? vehicle = _unitOfWork.Vehicle.Get(u => u.Id == vehicleId);
            return Json(vehicle);
        }
        [HttpPost]
        public IActionResult GetPolicy(int policyId)
        {
            // Your logic to fetch the corresponding VehicleName based on the selected VehicleNumber

            Policy? policy = _unitOfWork.Policy.Get(u => u.Id == policyId);
            return Json(policy);
        }
    }
}
