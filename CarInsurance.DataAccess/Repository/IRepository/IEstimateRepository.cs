using CarInsurance.Models;

namespace CarInsurance.DataAccess.Repository.IRepository
{
    public interface IEstimateRepository : IRepository<Estimate>
    {
        void Update(Estimate obj);

        IEnumerable<Estimate> GetAllByUserId(string userId);

    }
}
