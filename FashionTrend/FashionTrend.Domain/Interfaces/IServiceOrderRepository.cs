public interface IServiceOrderRepository : IBaseRepository<ServiceOrder>
{
    Task<ServiceOrder> GetBySupplierId(Guid idSupplier, CancellationToken cancellationToken);
    Task<ServiceOrder> GetByServiceId(Guid idService, CancellationToken cancellationToken);
    //Task<ServiceOrder> GetByStatus(ERequestStatus status, CancellationToken cancellationToken);
    //Task<ServiceOrder> GetByDate(DateTimeOffset date, CancellationToken cancellationToken);
}