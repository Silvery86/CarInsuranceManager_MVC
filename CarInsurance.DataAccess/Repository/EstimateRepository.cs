using CarInsurance.DataAccess.Data;
using CarInsurance.DataAccess.Repository.IRepository;
using CarInsurance.Models;
using Microsoft.EntityFrameworkCore;

namespace CarInsurance.DataAccess.Repository
{
    public class EstimateRepository : Repository<Estimate>, IEstimateRepository
    {
        private ApplicationDbContext _db;
        public EstimateRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public void Update(Estimate obj)
        {
            _db.Estimates.Update(obj);
        }


        public void Detach(object obj)
        {
            var entry = _db.Entry(obj);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Detached;
            }
        }

        public IEnumerable<Estimate> GetAllByUserId(string userId)
        {
            return _db.Estimates.Where(v => v.CustomerId == userId).ToList();
        }


    }
}
