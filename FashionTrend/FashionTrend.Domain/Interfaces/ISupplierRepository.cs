public interface ISupplierRepository : IBaseRepository<Supplier>
{
    Task<Supplier> GetByEmail(string email, CancellationToken cancellation);
    Task<List<Supplier>> GetByMaterial(string material, CancellationToken cancellationToken); //???
    Task<List<Supplier>> GetByMachine(ESewingMachine sewingmachine, CancellationToken cancellationToken); //???
}

