public interface IServiceRepository : IBaseRepository<Service>
{
    Task<List<Service>> GetByType(string type, CancellationToken cancellationToken);
    Task<List<Service>> GetByMachine(string machine, CancellationToken cancellationToken);
    Task<List<Service>> GetByMaterial(string material, CancellationToken cancellationToken);
    //Task<List<Service>> GetByDescription(string description, CancellationToken cancellationToken);
}