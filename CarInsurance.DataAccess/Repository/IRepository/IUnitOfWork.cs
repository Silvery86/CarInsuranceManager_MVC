namespace CarInsurance.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IVehicleRepository Vehicle { get; }
        void Save();
    }
}
