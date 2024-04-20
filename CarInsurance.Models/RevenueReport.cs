using System.ComponentModel.DataAnnotations;

namespace CarInsurance.Models
{
    public class RevenueReport
    {
        [Key] public int Id { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public double TotalAmount { get; set; }
    }
}
