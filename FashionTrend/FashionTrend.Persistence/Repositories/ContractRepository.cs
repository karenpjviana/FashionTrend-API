using Microsoft.EntityFrameworkCore;

public class ContractRepository : BaseRepository<Contract>, IContractRepository
{
    public ContractRepository(AppDbContext context) : base(context)
    {

    }

    public async Task<Contract> GetOrderId(Guid orderId, CancellationToken cancellationToken)
    {
        return await Context.Contracts.Where(x => x.OrderId.Equals(orderId)).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<Contract> GetSupplierId(Guid supplierId, CancellationToken cancellationToken)
    {
        return await Context.Contracts.Where(x => x.SupplierId.Equals(supplierId)).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<Contract> Status(EContractStatus status, CancellationToken cancellationToken)
    {
        return await Context.Contracts.Where(x => x.Status.Equals(status)).FirstOrDefaultAsync(cancellationToken);
    }
}
