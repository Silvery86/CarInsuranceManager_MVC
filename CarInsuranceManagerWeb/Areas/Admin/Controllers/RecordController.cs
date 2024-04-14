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
    public class RecordController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        public RecordController(UserManager<IdentityUser> userManager, IUnitOfWork unitOfWork)
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
            List<Record> records = (List<Record>)_unitOfWork.Record.GetAll();
            // Iterate over each vehicle to fetch associated UserName

            return View(records);
        }
        public IActionResult Process(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Record? Record = _unitOfWork.Record.Get(u => u.Id == id); // Find only work with primary key
            // Policy? Policy1 = _db.Policys.FirstOrDefault(u => u.Id == id); // Can work with other field not only primary key
            //Policy? Policy2 = _db.Policys.Where(u => u.Id == id).FirstOrDefault(); // Other method
            if (Record == null)
            {
                return NotFound();
            }
            return View(Record);
        }

        [HttpPost]
        public IActionResult Process(Record Record)
        {
            if (ModelState.IsValid)
            {
                // Update other properties as needed

                _unitOfWork.Record.Update(Record);
                TempData["success"] = "Policy edited successfully";
                _unitOfWork.Save();
            }
            return RedirectToAction("Index");
        }

    }
}
