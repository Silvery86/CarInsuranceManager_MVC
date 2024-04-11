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
    public class VehicleController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        public VehicleController(UserManager<IdentityUser> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;

        }
        public async Task<IActionResult> Index()
        {
            // Get all vehicles
            List<Vehicle> vehicles = _unitOfWork.Vehicle.GetAll().ToList();

            // Iterate over each vehicle to fetch associated UserName
            foreach (var vehicle in vehicles)
            {
                // Find the associated IdentityUser using UserManager
                var user = await _userManager.FindByIdAsync(vehicle.UserId);

                // If user is found, set the UserName in the Vehicle model
                if (user != null)
                {
                    // Assuming you have a property named UserName in the Vehicle model
                    vehicle.UserName = user.UserName;
                }
                else
                {
                    // Handle case where user is not found (optional)
                    // You can set a default value for UserName or handle it as needed
                    vehicle.UserName = "Unknown"; // Or any default value
                }
            }

            return View(vehicles);
        }

    }
}
