namespace CarInsurance.Models.ViewModels
{
    public class RevenueExpenseVM
    {
        public IEnumerable<RevenueReport> RevenueReport { get; set; }
        public IEnumerable<ExpenseReport> ExpenseReport { get; set; }
    }
}
