using CarInsurance.DataAccess.Data;
using CarInsurance.DataAccess.Repository.IRepository;

namespace CarInsurance.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IVehicleRepository Vehicle { get; private set; }
        public IPolicyRepository Policy { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Vehicle = new VehicleRepository(_db);
            Policy = new PolicyRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
