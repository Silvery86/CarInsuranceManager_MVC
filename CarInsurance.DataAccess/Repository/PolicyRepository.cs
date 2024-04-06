using CarInsurance.DataAccess.Data;
using CarInsurance.DataAccess.Repository.IRepository;
using CarInsurance.Models;
using Microsoft.EntityFrameworkCore;

namespace CarInsurance.DataAccess.Repository
{
    public class PolicyRepository : Repository<Policy>, IPolicyRepository
    {
        private ApplicationDbContext _db;
        public PolicyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public void Update(Policy policy)
        {
            _db.Policies.Update(policy);
        }


        public void Detach(object policy)
        {
            var entry = _db.Entry(policy);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Detached;
            }
        }


    }
}
