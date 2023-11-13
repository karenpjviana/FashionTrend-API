public interface IContractRepository : IBaseRepository<Contract>
{
    Task<Contract> GetOrderId(Guid orderId, CancellationToken cancellationToken);
    Task<Contract> GetSupplierId(Guid supplierId, CancellationToken cancellationToken);
    Task<Contract> Status(EContractStatus status, CancellationToken cancellationToken);
}
