using Microsoft.EntityFrameworkCore;

public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
{
    public SupplierRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Supplier> GetByEmail(string email, CancellationToken cancellationToken)
    {
        return await Context.Suppliers.FirstOrDefaultAsync(x => x.Email.Equals(email), cancellationToken);
    }

    public async Task<List<Supplier>> GetByMachine(ESewingMachine sewingmachine, CancellationToken cancellationToken)
    {
        return await Context.Suppliers.Where(x => x.SewingMachines.Contains(sewingmachine)).ToListAsync(cancellationToken);
    }

    public async Task<List<Supplier>> GetByMaterial(string material, CancellationToken cancellationToken)
    {
        return await Context.Suppliers.Where(x => x.Materials.Equals(material)).ToListAsync(cancellationToken);
    }
}