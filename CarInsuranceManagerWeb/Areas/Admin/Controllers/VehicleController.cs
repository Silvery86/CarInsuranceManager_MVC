using CarInsurance.DataAccess.Repository.IRepository;
using CarInsurance.Models;
using CarInsurance.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarInsuranceManagerWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class VehicleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public VehicleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public IActionResult Index()
        {
            List<Vehicle> vehicles = _unitOfWork.Vehicle.GetAll().ToList();
            return View(vehicles);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Vehicle vehicle)
        {
            // Check if VehicleValue is greater than zero
            if (vehicle.VehicleValue <= 0)
            {
                ModelState.AddModelError(nameof(vehicle.VehicleValue), "Vehicle value must be greater than zero.");
            }

            if (ModelState.IsValid)
            {
                // Check uniqueness for BodyNumber, EngineNumber, and Number
                if (_unitOfWork.Vehicle.GetAll().Any(v => v.Number == vehicle.Number))
                {
                    ModelState.AddModelError(nameof(vehicle.Number), "A vehicle with this number already exists.");
                }
                if (_unitOfWork.Vehicle.GetAll().Any(v => v.BodyNumber == vehicle.BodyNumber))
                {
                    ModelState.AddModelError(nameof(vehicle.BodyNumber), "A vehicle with this body number already exists.");
                }
                if (_unitOfWork.Vehicle.GetAll().Any(v => v.EngineNumber == vehicle.EngineNumber))
                {
                    ModelState.AddModelError(nameof(vehicle.EngineNumber), "A vehicle with this engine number already exists.");
                }

                // Check if there are any model errors after checking uniqueness and VehicleValue
                if (ModelState.ErrorCount > 0)
                {
                    return View(vehicle); // Return the view to display validation errors
                }

                _unitOfWork.Vehicle.Add(vehicle);
                TempData["success"] = "Vehicle created successfully";
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }

            return View(vehicle); // Return the view if ModelState is not valid
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
