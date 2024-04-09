using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarInsurance.Models.ViewModels
{
    public class EstimateVM
    {
        public Estimate Estimate { get; set; }
        public IEnumerable<SelectListItem> VehicleList { get; set; }
        public IEnumerable<SelectListItem> PolicyList { get; set; }

        public EstimateVM()
        {
            // Initialize collections to empty lists to prevent null reference exceptions
            VehicleList = new List<SelectListItem>();
            PolicyList = new List<SelectListItem>();
        }
    }
}
