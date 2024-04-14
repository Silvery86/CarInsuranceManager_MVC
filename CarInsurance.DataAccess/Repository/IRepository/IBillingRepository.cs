using CarInsurance.Models;

namespace CarInsurance.DataAccess.Repository.IRepository
{
    public interface IBillingRepository : IRepository<Billing>
    {
        void Update(Billing obj);
        IEnumerable<Billing> GetAllByUserId(string userId);

    }
}
