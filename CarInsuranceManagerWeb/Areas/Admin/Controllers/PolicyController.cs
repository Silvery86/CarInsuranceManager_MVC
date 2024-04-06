using CarInsurance.DataAccess.Repository.IRepository;
using CarInsurance.Models;
using CarInsurance.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarInsuranceManagerWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class PolicyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PolicyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public IActionResult Index()
        {
            List<Policy> Policys = _unitOfWork.Policy.GetAll().ToList();
            return View(Policys);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Policy Policy)
        {
            // Check if AnnualCost and BaseCost  is greater than zero
            if (Policy.AnnualCost <= 0)
            {
                ModelState.AddModelError(nameof(Policy.AnnualCost), "Annual Cost must be greater than zero.");
            }
            if (Policy.BaseCost <= 0)
            {
                ModelState.AddModelError(nameof(Policy.BaseCost), "Base Cost must be greater than zero.");
            }

            if (ModelState.IsValid)
            {
                // Check uniqueness for Policy Name
                if (_unitOfWork.Policy.GetAll().Any(v => v.Name == Policy.Name))
                {
                    ModelState.AddModelError(nameof(Policy.Name), "A Policy with this name already exists.");
                }


                // Check if there are any model errors after checking uniqueness and PolicyValue
                if (ModelState.ErrorCount > 0)
                {
                    return View(Policy); // Return the view to display validation errors
                }

                _unitOfWork.Policy.Add(Policy);
                TempData["success"] = "Policy created successfully";
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }

            return View(Policy); // Return the view if ModelState is not valid
        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Policy? Policy = _unitOfWork.Policy.Get(u => u.Id == id); // Find only work with primary key
            // Policy? Policy1 = _db.Policys.FirstOrDefault(u => u.Id == id); // Can work with other field not only primary key
            //Policy? Policy2 = _db.Policys.Where(u => u.Id == id).FirstOrDefault(); // Other method
            if (Policy == null)
            {
                return NotFound();
            }
            return View(Policy);
        }
        [HttpPost]
        public IActionResult Edit(Policy Policy)
        {
            // Check if PolicyValue is greater than zero
            // Check if AnnualCost and BaseCost  is greater than zero
            if (Policy.AnnualCost <= 0)
            {
                ModelState.AddModelError(nameof(Policy.AnnualCost), "Annual Cost must be greater than zero.");
            }
            if (Policy.BaseCost <= 0)
            {
                ModelState.AddModelError(nameof(Policy.BaseCost), "Base Cost must be greater than zero.");
            }

            if (ModelState.IsValid)
            {
                var existingPolicy = _unitOfWork.Policy.Get(u => u.Id == Policy.Id);

                // Check if the existing Policy exists
                if (existingPolicy == null)
                {
                    return NotFound(); // Or handle the scenario as appropriate
                }

                // Check uniqueness for BodyNumber, EngineNumber, and Number
                if (_unitOfWork.Policy.GetAll().Any(v => (v.Name == Policy.Name) && v.Id != Policy.Id))
                {
                    // Check uniqueness for Policy Name
                    if (_unitOfWork.Policy.GetAll().Any(v => v.Name == Policy.Name))
                    {
                        ModelState.AddModelError(nameof(Policy.Name), "A Policy with this name already exists.");
                    }

                    return View(Policy); // Return the view to display validation errors
                }

                // Detach the existing entity from the context
                _unitOfWork.Policy.Detach(existingPolicy);

                // Update the existing entity with the values of the submitted entity
                existingPolicy.Name = Policy.Name;
                existingPolicy.Warranty = Policy.Warranty;
                existingPolicy.BaseCost = Policy.BaseCost;
                existingPolicy.AnnualCost = Policy.AnnualCost;
                existingPolicy.Description = Policy.Description;

                // Update other properties as needed

                _unitOfWork.Policy.Update(existingPolicy);
                TempData["success"] = "Policy edited successfully";
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
            Policy? Policy = _unitOfWork.Policy.Get(u => u.Id == id); // Find only work with primary key
            // Policy? Policy1 = _db.Policys.FirstOrDefault(u => u.Id == id); // Can work with other field not only primary key
            //Policy? Policy2 = _db.Policys.Where(u => u.Id == id).FirstOrDefault(); // Other method
            if (Policy == null)
            {
                return NotFound();
            }
            return View(Policy);
        }
        [HttpPost, ActionName("Delete")]

        public IActionResult DeletePOST(int? id)
        {
            Policy? Policy = _unitOfWork.Policy.Get(u => u.Id == id);
            if (Policy == null)
            {
                return NotFound();
            }
            _unitOfWork.Policy.Remove(Policy);
            _unitOfWork.Save();
            TempData["success"] = "Policy remove successfully";
            return RedirectToAction("Index");

        }

    }
}
