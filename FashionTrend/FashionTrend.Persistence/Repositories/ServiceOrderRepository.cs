using Microsoft.EntityFrameworkCore;

public class ServiceOrderRepository : BaseRepository<ServiceOrder>, IServiceOrderRepository
{
    public ServiceOrderRepository(AppDbContext context) : base(context)
    {

    }

    public async Task<ServiceOrder> GetByServiceId(Guid idService, CancellationToken cancellationToken)
    {
        return await Context.ServiceOrders.Where(x => x.ServiceId.Equals(idService)).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<ServiceOrder> GetByStatus(ERequestStatus status, CancellationToken cancellationToken)
    {
        return await Context.ServiceOrders.Where(x => x.Status.Equals(status)).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<ServiceOrder> GetBySupplierId(Guid idSupplier, CancellationToken cancellationToken)
    {
        return await Context.ServiceOrders.Where(x => x.SupplierId.Equals(idSupplier)).FirstOrDefaultAsync(cancellationToken);
    }
}
