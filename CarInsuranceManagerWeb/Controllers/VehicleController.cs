using Microsoft.AspNetCore.Mvc;

namespace CarInsuranceManagerWeb.Controllers
{
    public class VehicleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
