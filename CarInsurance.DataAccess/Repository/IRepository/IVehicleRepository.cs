using CarInsurance.Models;

namespace CarInsurance.DataAccess.Repository.IRepository
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        void Update(Vehicle obj);
        void Detach(object existingVehicle);
    }
}
