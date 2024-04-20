using CarInsurance.DataAccess.Data;
using CarInsurance.DataAccess.Repository.IRepository;
using CarInsurance.Models;

namespace CarInsurance.DataAccess.Repository
{
    public class ClaimRepository : Repository<Claim>, IClaimRepository
    {
        private ApplicationDbContext _db;

        public ClaimRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Claim obj)
        {
            _db.Claims.Update(obj);
        }

        public IEnumerable<Claim> GetAllByUserId(string userId)
        {
            return _db.Claims.Where(v => v.CustomerId == userId).ToList();
        }

        public IEnumerable<ExpenseReport> GetExpenseReport()
        {
            return _db.Claims
                .Where(c => c.ClaimStatus == "Completed") // Filter by completed claims
                .GroupBy(c => new { c.DateOfAccident.Year, c.DateOfAccident.Month })
                .Select(g => new ExpenseReport
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    TotalAmount = g.Sum(c => c.ClaimableAmount)
                })
                .ToList();
        }
    }
}
