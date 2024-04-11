using CarInsurance.Models;

namespace CarInsurance.DataAccess.Repository.IRepository
{
    public interface IRecordRepository : IRepository<Record>
    {
        void Update(Record obj);
        IEnumerable<Record> GetAllByUserId(string userId);

    }
}
