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
            List<Claim> claims = (List<Claim>)_unitOfWork.Claim.GetAll();
            // Iterate over each vehicle to fetch associated UserName

            return View(claims);
        }



        public IActionResult Process(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Claim? claim = _unitOfWork.Claim.Get(u => u.Id == id); // Find only work with primary key
            // Policy? Policy1 = _db.Policys.FirstOrDefault(u => u.Id == id); // Can work with other field not only primary key
            //Policy? Policy2 = _db.Policys.Where(u => u.Id == id).FirstOrDefault(); // Other method
            if (claim == null)
            {
                return NotFound();
            }
            return View(claim);
        }

        [HttpPost]
        public IActionResult Process(Claim claim)
        {
            if (ModelState.IsValid)
            {
                // Update other properties as needed
                if (claim.ClaimStatus == "Complete")
                {
                    claim.ClaimAt = DateTime.Now;
                }

                _unitOfWork.Claim.Update(claim);
                TempData["success"] = "Claim Record edited successfully";
                _unitOfWork.Save();
            }
            return RedirectToAction("Index");
        }

        public IActionResult View(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Claim? claim = _unitOfWork.Claim.Get(u => u.Id == id); // Find only work with primary key
            // Policy? Policy1 = _db.Policys.FirstOrDefault(u => u.Id == id); // Can work with other field not only primary key
            //Policy? Policy2 = _db.Policys.Where(u => u.Id == id).FirstOrDefault(); // Other method
            if (claim == null)
            {
                return NotFound();
            }
            return View(claim);
        }



    }
}
