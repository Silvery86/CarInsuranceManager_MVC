using CarInsurance.DataAccess.Data;
using CarInsurance.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarInsuranceManagerWeb.Controllers
{
    public class VehicleController : Controller
    {
        private readonly ApplicationDbContext _db;
        public VehicleController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            List<Vehicle> vehicles = _db.Vehicles.ToList();
            return View(vehicles);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                // Check uniqueness for BodyNumber, EngineNumber, and Number
                if (_db.Vehicles.Any(v => v.Number == vehicle.Number ||
                                           v.BodyNumber == vehicle.BodyNumber ||
                                           v.EngineNumber == vehicle.EngineNumber))
                {
                    if (_db.Vehicles.Any(v => v.Number == vehicle.Number))
                    {
                        ModelState.AddModelError(nameof(vehicle.Number), "A vehicle with this number already exists.");
                    }
                    if (_db.Vehicles.Any(v => v.BodyNumber == vehicle.BodyNumber))
                    {
                        ModelState.AddModelError(nameof(vehicle.BodyNumber), "A vehicle with this body number already exists.");
                    }
                    if (_db.Vehicles.Any(v => v.EngineNumber == vehicle.EngineNumber))
                    {
                        ModelState.AddModelError(nameof(vehicle.EngineNumber), "A vehicle with this engine number already exists.");
                    }

                    return View(vehicle); // Return the view to display validation errors
                }
                _db.Vehicles.Add(vehicle);
                TempData["success"] = "Vehicle create successfully";
                _db.SaveChanges();
            }
            return RedirectToAction("Index");

        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Vehicle? vehicle = _db.Vehicles.Find(id); // Find only work with primary key
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
            if (ModelState.IsValid)
            {
                // Check uniqueness for BodyNumber, EngineNumber, and Number
                if (_db.Vehicles.Any(v => (v.Number == vehicle.Number || v.BodyNumber == vehicle.BodyNumber || v.EngineNumber == vehicle.EngineNumber) && v.Id != vehicle.Id))
                {
                    if (_db.Vehicles.Any(v => v.Number == vehicle.Number && v.Id != vehicle.Id))
                    {
                        ModelState.AddModelError(nameof(vehicle.Number), "A vehicle with this number already exists.");
                    }
                    if (_db.Vehicles.Any(v => v.BodyNumber == vehicle.BodyNumber && v.Id != vehicle.Id))
                    {
                        ModelState.AddModelError(nameof(vehicle.BodyNumber), "A vehicle with this body number already exists.");
                    }
                    if (_db.Vehicles.Any(v => v.EngineNumber == vehicle.EngineNumber && v.Id != vehicle.Id))
                    {
                        ModelState.AddModelError(nameof(vehicle.EngineNumber), "A vehicle with this engine number already exists.");
                    }

                    return View(vehicle); // Return the view to display validation errors
                }
                _db.Vehicles.Update(vehicle);
                TempData["success"] = "Vehicle edit successfully";
                _db.SaveChanges();
            }
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Vehicle? vehicle = _db.Vehicles.Find(id); // Find only work with primary key
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
            Vehicle? vehicle = _db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            _db.Vehicles.Remove(vehicle);
            _db.SaveChanges();
            TempData["success"] = "Vehicle remove successfully";
            return RedirectToAction("Index");

        }
    }
}
