namespace CarInsurance.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IVehicleRepository Vehicle { get; }
        IPolicyRepository Policy { get; }

        IEstimateRepository Estimate { get; }
        void Save();
        Task<int> SaveChangesAsync();
    }
}
