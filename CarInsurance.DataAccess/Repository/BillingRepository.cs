using CarInsurance.DataAccess.Data;
using CarInsurance.DataAccess.Repository.IRepository;
using CarInsurance.Models;

namespace CarInsurance.DataAccess.Repository
{
    public class BillingRepository : Repository<Billing>, IBillingRepository
    {
        private ApplicationDbContext _db;
        public BillingRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public void Update(Billing obj)
        {
            _db.Billings.Update(obj);
        }

        public IEnumerable<Billing> GetAllByUserId(string userId)
        {
            return _db.Billings.Where(v => v.CustomerId == userId).ToList();
        }



    }
}
