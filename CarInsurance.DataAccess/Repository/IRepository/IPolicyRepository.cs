using CarInsurance.Models;

namespace CarInsurance.DataAccess.Repository.IRepository
{
    public interface IPolicyRepository : IRepository<Policy>
    {
        void Update(Policy obj);
        void Detach(object existingPolicy);
    }
}
