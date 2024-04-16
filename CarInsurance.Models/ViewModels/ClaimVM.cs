using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarInsurance.Models.ViewModels
{
    public class ClaimVM
    {
        public Claim Claim { get; set; }
        public IEnumerable<SelectListItem> BillList { get; set; }


    }
}
