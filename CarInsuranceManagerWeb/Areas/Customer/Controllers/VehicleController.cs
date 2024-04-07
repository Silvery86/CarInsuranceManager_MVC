using CarInsurance.DataAccess.Repository.IRepository;
using CarInsurance.Models;
using CarInsurance.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarInsuranceManagerWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = SD.Role_Customer)]
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
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account"); // Redirect if user is not authenticated
            }

            // Fetch vehicles for the current user
            List<Vehicle> vehicles = (List<Vehicle>)_unitOfWork.Vehicle.GetAllByUserId(currentUser.Id);
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
        public IActionResult Create()
        {
            return View();
        }

        public HttpContext GetHttpContext()
        {
            return HttpContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Vehicle vehicle)
        {
            ModelState.Clear();
            // Check if VehicleValue is greater than zero
            if (vehicle.VehicleValue <= 0)
            {
                ModelState.AddModelError(nameof(vehicle.VehicleValue), "Vehicle value must be greater than zero.");
            }

            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (currentUser == null)
            {
                // Handle if user is not authenticated
                return RedirectToAction("Login", "Account");
            }

            // Assign the current user directly to the IdentityUser navigation property
            vehicle.UserId = currentUser.Id;

            if (ModelState.IsValid)
            {
                // Check for uniqueness of Number, BodyNumber, and EngineNumber
                var existingVehicles = _unitOfWork.Vehicle.GetAll();
                if (existingVehicles.Any(v => v.Number == vehicle.Number))
                {
                    ModelState.AddModelError(nameof(vehicle.Number), "A vehicle with this number already exists.");
                }
                if (existingVehicles.Any(v => v.BodyNumber == vehicle.BodyNumber))
                {
                    ModelState.AddModelError(nameof(vehicle.BodyNumber), "A vehicle with this body number already exists.");
                }
                if (existingVehicles.Any(v => v.EngineNumber == vehicle.EngineNumber))
                {
                    ModelState.AddModelError(nameof(vehicle.EngineNumber), "A vehicle with this engine number already exists.");
                }

                // Check if there are any model errors after checking uniqueness and VehicleValue
                if (ModelState.ErrorCount > 0)
                {
                    return View(vehicle); // Return the view to display validation errors
                }

                // Add the vehicle to the context and save changes
                _unitOfWork.Vehicle.Add(vehicle);
                TempData["success"] = "Vehicle created successfully";
                await _unitOfWork.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            // Return the view to display validation errors
            return View(vehicle);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Vehicle? vehicle = _unitOfWork.Vehicle.Get(u => u.Id == id); // Find only work with primary key
            // Vehicle? vehicle1 = _db.Vehicles.FirstOrDefault(u => u.Id == id); // Can work with other field not only primary key
            //Vehicle? vehicle2 = _db.Vehicles.Where(u => u.Id == id).FirstOrDefault(); // Other method
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }
        [HttpPost]
        public IActionResult Edit(Vehicle vehicle)
        {
            // Check if VehicleValue is greater than zero
            if (vehicle.VehicleValue <= 0)
            {
                ModelState.AddModelError(nameof(vehicle.VehicleValue), "Vehicle value must be greater than zero.");
            }
            if (ModelState.IsValid)
            {
                var existingVehicle = _unitOfWork.Vehicle.Get(u => u.Id == vehicle.Id);

                // Check if the existing vehicle exists
                if (existingVehicle == null)
                {
                    return NotFound(); // Or handle the scenario as appropriate
                }

                // Check uniqueness for BodyNumber, EngineNumber, and Number
                if (_unitOfWork.Vehicle.GetAll().Any(v => (v.Number == vehicle.Number || v.BodyNumber == vehicle.BodyNumber || v.EngineNumber == vehicle.EngineNumber) && v.Id != vehicle.Id))
                {
                    if (_unitOfWork.Vehicle.GetAll().Any(v => v.Number == vehicle.Number && v.Id != vehicle.Id))
                    {
                        ModelState.AddModelError(nameof(vehicle.Number), "A vehicle with this number already exists.");
                    }
                    if (_unitOfWork.Vehicle.GetAll().Any(v => v.BodyNumber == vehicle.BodyNumber && v.Id != vehicle.Id))
                    {
                        ModelState.AddModelError(nameof(vehicle.BodyNumber), "A vehicle with this body number already exists.");
                    }
                    if (_unitOfWork.Vehicle.GetAll().Any(v => v.EngineNumber == vehicle.EngineNumber && v.Id != vehicle.Id))
                    {
                        ModelState.AddModelError(nameof(vehicle.EngineNumber), "A vehicle with this engine number already exists.");
                    }

                    return View(vehicle); // Return the view to display validation errors
                }

                // Detach the existing entity from the context
                _unitOfWork.Vehicle.Detach(existingVehicle);

                // Update the existing entity with the values of the submitted entity
                existingVehicle.Name = vehicle.Name;
                existingVehicle.OwnerName = vehicle.OwnerName;
                existingVehicle.Model = vehicle.Model;
                existingVehicle.Version = vehicle.Version;
                existingVehicle.Rate = vehicle.Rate;
                existingVehicle.BodyNumber = vehicle.BodyNumber;
                existingVehicle.EngineNumber = vehicle.EngineNumber;
                existingVehicle.Number = vehicle.Number;
                // Update other properties as needed

                _unitOfWork.Vehicle.Update(existingVehicle);
                TempData["success"] = "Vehicle edited successfully";
                _unitOfWork.Save();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Vehicle? vehicle = _unitOfWork.Vehicle.Get(u => u.Id == id); // Find only work with primary key
            // Vehicle? vehicle1 = _db.Vehicles.FirstOrDefault(u => u.Id == id); // Can work with other field not only primary key
            //Vehicle? vehicle2 = _db.Vehicles.Where(u => u.Id == id).FirstOrDefault(); // Other method
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }
        [HttpPost, ActionName("Delete")]

        public IActionResult DeletePOST(int? id)
        {
            Vehicle? vehicle = _unitOfWork.Vehicle.Get(u => u.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }
            _unitOfWork.Vehicle.Remove(vehicle);
            _unitOfWork.Save();
            TempData["success"] = "Vehicle remove successfully";
            return RedirectToAction("Index");

        }

    }
}
