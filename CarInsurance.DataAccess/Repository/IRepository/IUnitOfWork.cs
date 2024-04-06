namespace CarInsurance.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IVehicleRepository Vehicle { get; }
        IPolicyRepository Policy { get; }
        void Save();
    }
}
