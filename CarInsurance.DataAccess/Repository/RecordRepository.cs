using CarInsurance.DataAccess.Data;
using CarInsurance.DataAccess.Repository.IRepository;
using CarInsurance.Models;

namespace CarInsurance.DataAccess.Repository
{
    public class RecordRepository : Repository<Record>, IRecordRepository
    {
        private ApplicationDbContext _db;
        public RecordRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public void Update(Record record)
        {
            _db.Records.Update(record);
        }

        public IEnumerable<Record> GetAllByUserId(string userId)
        {
            return _db.Records.Where(v => v.CustomerId == userId).ToList();
        }



    }
}
