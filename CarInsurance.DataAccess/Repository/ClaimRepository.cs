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


    }
}
