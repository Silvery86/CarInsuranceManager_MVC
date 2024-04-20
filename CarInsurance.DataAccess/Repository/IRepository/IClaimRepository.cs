using CarInsurance.Models;


namespace CarInsurance.DataAccess.Repository.IRepository
{
    public interface IClaimRepository : IRepository<Claim>
    {
        void Update(Claim obj);

        IEnumerable<Claim> GetAllByUserId(string userId);
        IEnumerable<ExpenseReport> GetExpenseReport();
    }
}
