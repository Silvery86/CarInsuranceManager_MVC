using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarInsurance.Models.ViewModels
{
    public class EstimateVM
    {
        public Estimate Estimate { get; set; }
        public IEnumerable<SelectListItem> VehicleList { get; set; }
        public IEnumerable<SelectListItem> PolicyList { get; set; }


    }
}
