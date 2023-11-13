using Microsoft.EntityFrameworkCore;

public class ServiceRepository :  BaseRepository<Service>, IServiceRepository
{
    public ServiceRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<Service>> GetByType(string type, CancellationToken cancellationToken)
    {
        return await Context.Services.Where(x => x.Type.Equals(type)).ToListAsync(cancellationToken);
    }

    public async Task<List<Service>> GetByMachine(string sewingmachine, CancellationToken cancellationToken)
    {
        return await Context.Services.Where(x => x.SewingMachines.Equals(sewingmachine)).ToListAsync(cancellationToken);
    }

    public async Task<List<Service>> GetByMaterial(string material, CancellationToken cancellationToken)
    {
        return await Context.Services.Where(x => x.Materials.Equals(material)).ToListAsync(cancellationToken);
    }
}
