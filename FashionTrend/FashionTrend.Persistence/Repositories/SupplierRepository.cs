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

    public async Task<List<Supplier>> GetByMachine(string sewingmachine, CancellationToken cancellationToken)
    {
        return await Context.Suppliers.Where(x => x.SewingMachines.Equals(sewingmachine)).ToListAsync(cancellationToken);
    }

    public async Task<List<Supplier>> GetByMaterials(string material, CancellationToken cancellationToken)
    {
        return await Context.Suppliers.Where(x => x.Materials.Equals(material)).ToListAsync(cancellationToken);
    }
}