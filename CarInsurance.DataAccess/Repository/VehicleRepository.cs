using CarInsurance.DataAccess.Data;
using CarInsurance.DataAccess.Repository.IRepository;
using CarInsurance.Models;
using Microsoft.EntityFrameworkCore;

namespace CarInsurance.DataAccess.Repository
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        private ApplicationDbContext _db;
        public VehicleRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public void Update(Vehicle vehicle)
        {
            _db.Vehicles.Update(vehicle);
        }


        public void Detach(object vehicle)
        {
            var entry = _db.Entry(vehicle);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Detached;
            }
        }
    }
}
