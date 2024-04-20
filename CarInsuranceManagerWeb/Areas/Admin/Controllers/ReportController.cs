using CarInsurance.DataAccess.Repository.IRepository;
using CarInsurance.Models.ViewModels;
using CarInsurance.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarInsuranceManagerWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ReportController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public ReportController(UserManager<IdentityUser> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var revenues = _unitOfWork.Billing.GetRevenueReport().ToList();
            var expenses = _unitOfWork.Claim.GetExpenseReport().ToList();

            var revenueExpense = new RevenueExpenseVM()
            {
                RevenueReport = revenues,
                ExpenseReport = expenses,
            };

            return View(revenueExpense);
        }
    }
}
