using CarInsuranceManagerWeb.Data;
using CarInsuranceManagerWeb.Models;
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
                _db.SaveChanges();
            }
            return RedirectToAction("Index");

        }
    }
}
