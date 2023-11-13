public interface ISupplierRepository : IBaseRepository<Supplier>
{
    Task<Supplier> GetByEmail(string email, CancellationToken cancellation);
    Task<List<Supplier>> GetByMaterials(string material, CancellationToken cancellationToken); //???
    Task<List<Supplier>> GetByMachine(string sewingmachine, CancellationToken cancellationToken); //???
}

