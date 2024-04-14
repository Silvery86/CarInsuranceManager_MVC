namespace CarInsurance.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IVehicleRepository Vehicle { get; }
        IPolicyRepository Policy { get; }

        IEstimateRepository Estimate { get; }

        IRecordRepository Record { get; }
        IBillingRepository Billing { get; }
        void Save();
        Task<int> SaveChangesAsync();
    }
}
