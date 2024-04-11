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
        private readonly IWebHostEnvironment _webHostEnvironment;
        public EstimateController(UserManager<IdentityUser> userManager, IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Estimate()
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
                    Value = u.Number.ToString(),
                }),
                PolicyList = _unitOfWork.Policy.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                }),

            };
            return View(estimateVM);
        }
        public HttpContext GetHttpContext()
        {
            return HttpContext;
        }

        [HttpPost]
        public async Task<IActionResult> Estimate(EstimateVM estimateVM)
        {

            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account"); // Redirect if user is not authenticated
            }
            estimateVM.Estimate.CustomerId = currentUser.Id;

            // Check if a file is uploaded
            if (estimateVM.Estimate.CustomerAddProveFile == null || estimateVM.Estimate.CustomerAddProveFile.Length == 0)
            {
                ModelState.AddModelError(nameof(estimateVM.Estimate.CustomerAddProveFile), "Please upload a file.");
                estimateVM.VehicleList = _unitOfWork.Vehicle.GetAllByUserId(currentUser.Id).Select(u => new SelectListItem
                {
                    Text = u.Number,
                    Value = u.Number.ToString(),
                });

                estimateVM.PolicyList = _unitOfWork.Policy.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                });


                return View(estimateVM);
            }

            // Check if the uploaded file is an image
            if (!IsImageFile(estimateVM.Estimate.CustomerAddProveFile))
            {
                ModelState.AddModelError(nameof(estimateVM.Estimate.CustomerAddProveFile), "Please upload a valid image file.");
                estimateVM.VehicleList = _unitOfWork.Vehicle.GetAllByUserId(currentUser.Id).Select(u => new SelectListItem
                {
                    Text = u.Number,
                    Value = u.Number.ToString(),
                });

                estimateVM.PolicyList = _unitOfWork.Policy.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                });

                return View(estimateVM);
            }

            // Handle the uploaded file
            if (estimateVM.Estimate.CustomerAddProveFile != null)
            {
                // Generate a unique file name
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(estimateVM.Estimate.CustomerAddProveFile.FileName);

                // Save the file or process it as needed
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await estimateVM.Estimate.CustomerAddProveFile.CopyToAsync(fileStream);
                }

                // Save the file path to the model
                estimateVM.Estimate.CustomerAddProve = uniqueFileName;


            }



            return RedirectToAction("Checkout", estimateVM.Estimate);

        }
        private bool IsImageFile(IFormFile file)
        {
            if (file.ContentType.ToLower() == "image/jpeg" ||
                file.ContentType.ToLower() == "image/jpg" ||
                file.ContentType.ToLower() == "image/png" ||
                file.ContentType.ToLower() == "image/gif")
            {
                return true;
            }
            return false;
        }


        public IActionResult Checkout(Estimate estimate)
        {

            return View("Checkout", estimate);
        }

        [HttpPost, ActionName("Checkout")]
        public async Task<IActionResult> CheckoutPOST(Estimate estimate)
        {
            ModelState.Clear();

            var record = new Record()
            {
                CustomerId = estimate.CustomerId,
                CustomerName = estimate.CustomerName,
                CustomerAddress = estimate.CustomerAddress,
                CustomerPhoneNumber = estimate.CustomerPhoneNumber,
                VehiclePolicyType = estimate.VehiclePolicyType,
                PolicyDate = DateTime.Now,
                VehicleName = estimate.VehicleName,
                VehicleModel = estimate.VehicleModel,
                VehicleNumber = estimate.VehicleNumber,
                VehicleVersion = estimate.VehicleVersion,
                VehicleValue = estimate.VehicleValue,
                VehicleRate = estimate.VehicleRate,
                VehicleWarranty = estimate.VehicleWarranty,
                CustomerAddProve = estimate.CustomerAddProve,
                InsuranceCost = estimate.EstimateCost,

            };

            TryValidateModel(record);

            if (ModelState.IsValid)
            {


                _unitOfWork.Record.Add(record);
                TempData["success"] = "Record created successfully!";
                await _unitOfWork.SaveChangesAsync();

                // Pass the record object to the view
                return View("Thankyou", record);
            }

            return View("Error");
        }

        [HttpPost]
        public IActionResult GetVehicle(string vehicleNumber)
        {
            // Your logic to fetch the corresponding VehicleName based on the selected VehicleNumber

            Vehicle? vehicle = _unitOfWork.Vehicle.Get(u => u.Number == vehicleNumber);
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
